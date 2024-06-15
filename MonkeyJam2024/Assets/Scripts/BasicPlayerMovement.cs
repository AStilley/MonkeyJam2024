using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rigidbody2;
    private Vector2 moveDirection;

    private bool moveEnabled = true;

    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveEnabled)
        {
            ProcessInputs();
        }
        else
        {
            rigidbody2.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (moveEnabled)
        {
            Move();
        }
        else
        {
            rigidbody2.velocity = Vector2.zero;
        }
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    private void Move()
    {
        rigidbody2.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}

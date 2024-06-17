using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FruitBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] int fruitNumber;
    float moveSpeed = 4f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Debug.Log(gameObject.name + " was created!");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, moveSpeed);

        if (this.transform.position.y >= 8)
        {
            Destroy(this.gameObject);        
        }
    }

    public void SetFruitNumber(int fruitNum)
    {
        fruitNumber = fruitNum;
    }
    public int GetFruitNumber()
    {
        return fruitNumber;
    }
}

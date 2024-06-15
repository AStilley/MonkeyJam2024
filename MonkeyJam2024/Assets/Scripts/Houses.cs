using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Houses : MonoBehaviour
{
    // Start is called before the first frame update

    private float moveSpeed;


    [SerializeField] int wallID;
    [SerializeField] int roofID;

    [SerializeField] SpriteRenderer walls;
    [SerializeField] SpriteRenderer roof;

    [SerializeField] Sprite[] wallArray;
    [SerializeField] Sprite[] roofArray;
    /*
     * 0 = Blue
     * 1 = Red
     * 2 = Yellow
     * 3 = Green
     * 4 = Orange
     * 5 = Purple
     */

    private void Awake()
    {
        SetUpHouse();
        walls.sprite = wallArray[wallID];
        roof.sprite = roofArray[roofID];
    }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Houses Movement
        //transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);

        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + "hit the house!");
        Destroy(collision.gameObject);
    }

    private void SetUpHouse()
    {
        wallID = Random.Range(0, 6);
        roofID = Random.Range(0, 6);
    }

    public bool FruitPass()
    {
        //This determines if the fruit is acceptable
        return true;

    }
    public int GetWallID()
    {
        return wallID;
    }
    public int GetRoofID()
    {
        return roofID;
    }
}

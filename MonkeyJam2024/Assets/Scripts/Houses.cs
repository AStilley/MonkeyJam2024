using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Houses : MonoBehaviour
{
    // Start is called before the first frame update

    private float moveSpeed;
    Score scoreBoard;

    RulesManager rulesManager;
    LoseManager loseManager;
    [SerializeField] int wallID;
    [SerializeField] int roofID;
    [SerializeField] int fruitID;
    [SerializeField] int fruitID2;
    bool hit = false;
    bool hit2 = false;
    [SerializeField] SpriteRenderer walls;
    [SerializeField] SpriteRenderer roof;
    [SerializeField] SpriteRenderer fruit;
    [SerializeField] SpriteRenderer fruit2;
    [SerializeField] SpriteRenderer circle;
    [SerializeField] SpriteRenderer circle2;

    [SerializeField] Sprite[] wallArray;
    [SerializeField] Sprite[] roofArray;
    [SerializeField] Sprite[] fruitArray;
    /*
     * 0 = Blue, Apple
     * 1 = Red, Banana
     * 2 = Yellow, Cherry
     * 3 = Green, Grape
     * 4 = Orange, Orange,
     * 5 = Purple, Peach
     * 6 = Pear
     * 7 = Strawberry
     */

    private void Awake()
    {
        scoreBoard = GameManager.Instance.score;
        loseManager = GameObject.Find("Managers").GetComponent<LoseManager>();
        rulesManager = GameObject.Find("Managers").GetComponent<RulesManager>();
        SetUpHouse();
        walls.sprite = wallArray[wallID];
        roof.sprite = roofArray[roofID];
        fruit.sprite = fruitArray[fruitID];
        fruit2.sprite = fruitArray[fruitID2];
    }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Houses Movement
        transform.position = new Vector3(transform.position.x - Time.deltaTime * 2, transform.position.y, transform.position.z);

        if (this.transform.position.x <= -15)
        {
            if (rulesManager.TestNotOnOurList(wallID, roofID))
            {
                if (!hit)
                {
                    scoreBoard.AddScore(-10);
                    Debug.Log("You let a house go without the fruit they wanted.");
                    loseManager.TakeDamage();
                }
                if (!hit2)
                {
                    scoreBoard.AddScore(-10);
                    Debug.Log("You let a house go without the fruit they wanted.");
                    loseManager.TakeDamage();
                }

            }
            else
            {//This house was not on our list, no penalty
                
            }

            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (rulesManager.TestAgainstRules(wallID, roofID, collision.GetComponent<FruitBullet>().GetFruitNumber()))
        {

        }
        else
        {
            circle.color = Color.green; circle2.color = Color.green;
            Destroy(collision.gameObject);
            return;
        }
        //Debug.Log(collision.name + " hit the house!");
        if (collision.GetComponent<FruitBullet>().GetFruitNumber() == fruitID)
        {
            if (hit)
            {
                

            }
            else
            {
                scoreBoard.AddScore(5);
                circle.color = Color.green;
                hit = true;
            }

        }
        if (collision.GetComponent<FruitBullet>().GetFruitNumber() == fruitID2)
        {
            if (hit2)
            {


            }
            else
            {
                scoreBoard.AddScore(5);
                circle2.color = Color.green;
                hit2 = true;
            }

        }
        if(collision.GetComponent<FruitBullet>().GetFruitNumber() != fruitID && collision.GetComponent<FruitBullet>().GetFruitNumber() !=  fruitID2)
        {
            Debug.Log("They didn't want this fruit.");
            loseManager.TakeDamage();
            scoreBoard.AddScore(-5);
        }



        Destroy(collision.gameObject);
    }

    private void SetUpHouse()
    {
        wallID = Random.Range(0, 6);
        roofID = Random.Range(0, 6);
        fruitID = Random.Range(0, 8);
        fruitID2 = Random.Range(0, 8);
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

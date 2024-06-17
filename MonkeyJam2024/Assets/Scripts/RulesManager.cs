using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RulesManager : MonoBehaviour
{
    LoseManager loseManager;
    Score scoreBoard;
    int wall;
    int roof;
    int fruit;

    string[] houseColor = { "Blue", "Red", "Yellow", "Green", "Orange", "Purple" };
    string[] fruitName = { "Apple", "Banana", "Cherry", "Grape", "Orange", "Peach", "Pear", "Strawberry" };

    int notebook1 = -1;
    int notebook2 = -1;
    int notebook3 = -1;
    int notebook4 = -1;

    int notebook1Fruit = -1;
    int notebook2Fruit = -1;
    int notebook3Fruit = -1;
    int notebook4Fruit = -1;

    [SerializeField] TMP_Text notebook1Text;
    [SerializeField] TMP_Text notebook2Text;
    [SerializeField] TMP_Text notebook3Text;
    [SerializeField] TMP_Text notebook4Text;

    int ruleCount = 0;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        loseManager = GameObject.Find("Managers").GetComponent<LoseManager>();
        scoreBoard = GameManager.Instance.score;
        notebook1Text = GameManager.Instance.notebook1;
        notebook2Text = GameManager.Instance.notebook2;
        notebook3Text = GameManager.Instance.notebook3;
        notebook4Text = GameManager.Instance.notebook4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActuallyLovesRule()
    {//X WANTS ONLY Y FRUIT
        notebook1Fruit = Random.Range(0, 8);

        if (Random.Range(0, 2) == 0)
        {//wall
            notebook1 = Random.Range(0, 6);

            notebook1Text.text = houseColor[notebook1] + " wall houses actually also loves " + fruitName[notebook1Fruit];
        }
        else
        {//roof
            notebook1 = Random.Range(0, 6);

            notebook1Text.text = houseColor[notebook1] + " roof houses actually also loves " + fruitName[notebook1Fruit];
            notebook1 += 10;
        }




    }
    public void ActuallyHatesRule()
    {//X ACTUALLY HATES Y fruit
        notebook2Fruit = Random.Range(0, 8);

        if (Random.Range(0, 2) == 0)
        {//wall
            notebook2 = Random.Range(0, 6);
            notebook2Text.text = houseColor[notebook2] + " wall houses actually hate " + fruitName[notebook2Fruit];
        }
        else
        {//roof
            notebook2 = Random.Range(0, 6);
            notebook2Text.text = houseColor[notebook2] + " roof houses actually hate " + fruitName[notebook2Fruit];
            notebook2 += 10;
        }

    }

    public void WantsAnyFruit()
    {
        if (Random.Range(0, 2) == 0)
        {//wall
            notebook3 = Random.Range(0, 6);
            notebook3Text.text = houseColor[notebook3] + " wall houses actually would like any fruit.";
        }
        else
        {//roof
            notebook3 = Random.Range(0, 6);
            notebook3Text.text = houseColor[notebook3] + " roof houses actually would like any fruit.";
            notebook3 += 10;
        }
    }

    public void NotOnOurList()
    {
        if (Random.Range(0, 2) == 0)
        {//wall
            notebook4 = Random.Range(0, 6);
            notebook4Text.text = houseColor[notebook4] + " wall houses aren't subscribed to our service.";
        }
        else
        {//roof
            notebook4 = Random.Range(0, 6);
            notebook4Text.text = houseColor[notebook4] + " roof houses aren't subscribed to our service.";
            notebook4 += 10;
        }


    }

    public bool TestAgainstRules(int wallNum, int roofNum, int fruitNum)
    {
        //TRUE = continue with the rest of the checks
        //FALSE = skip the other checks
        if (wallNum == notebook1 || roofNum == (notebook1 - 10))
        {

            if (notebook1Fruit == fruitNum)
            {
                scoreBoard.AddScore(20);
                return false;
            }
        }

        if (wallNum == notebook2 || roofNum == (notebook2 - 10))
        {

            if (notebook2Fruit == fruitNum)
            {
                Debug.Log("They HATE this fruit!.");
                loseManager.TakeDamage();
                scoreBoard.AddScore(-20);
                return false;
            }
        }

        if (wallNum == notebook3 || roofNum == (notebook3 - 10))
        {
            scoreBoard.AddScore(10);
            return false;
            
        }
        if (wallNum == notebook4 || roofNum == (notebook4 - 10))
        {
            Debug.Log("They're not on our list!.");
            loseManager.TakeDamage();
            scoreBoard.AddScore(-10);
            return false;
        }

        return true;
        
    }

    public bool TestNotOnOurList(int wallNum, int roofNum)
    {
        if (wallNum == notebook4 || roofNum == (notebook4 - 10))
        {
            scoreBoard.AddScore(-10);
            return false;
        }
        return true;
    }

    public void NewRules()
    {
        if(ruleCount >= 0)
        {
            ActuallyLovesRule();
        }
        else if(ruleCount >= 1)
        {
            ActuallyHatesRule();
        }
        else if(ruleCount >= 2)
        {
            WantsAnyFruit();
        }
        else if(ruleCount >= 3)
        {
            NotOnOurList();
        }

        ruleCount++;
    }
}

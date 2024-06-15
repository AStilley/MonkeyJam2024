using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitShoot : MonoBehaviour
{
    /*
     * This script will be attatched to the fruit buttons. On Click, the coresponsing fruit will shoot from the player.
     */

    [Header("References")]
    [SerializeField] GameObject fruitBullet;
    int fruitNumber = -1;
    string nameString = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFruit(int fruitNum)
    {
        fruitNumber = fruitNum;
    }

    public void Shoot(Sprite fruit)
    {

        var fruitToMake = Instantiate(fruitBullet, this.gameObject.transform.position, Quaternion.identity);
        fruitToMake.GetComponent<SpriteRenderer>().sprite = fruit;
        fruitToMake.GetComponent<FruitBullet>().SetFruitNumber(fruitNumber);
        switch (fruitNumber)
        {
            case 0:
                nameString = "Apple";
                break;
            case 1:
                nameString = "Banana";
                break;
            case 2:
                nameString = "Cherry";
                break;
            case 3:
                nameString = "Grape";
                break;
            case 4:
                nameString = "Orange";
                break;
            case 5:
                nameString = "Peach";
                break;
            case 6:
                nameString = "Pear";
                break;
            case 7:
                nameString = "Strawberry";
                break;
            default:
                nameString = "ERROR";
                break;
        }
        fruitToMake.gameObject.name = nameString;
    }

}

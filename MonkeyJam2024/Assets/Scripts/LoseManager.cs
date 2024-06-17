using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [SerializeField] int health = 5;

    [SerializeField] GameObject[] hearts;

    [SerializeField] TMP_Text[] gameOverText;

    [SerializeField] RulesManager rulesManager;
    [SerializeField] BackgroundScroll bcScroll;
    [SerializeField] BasicPlayerMovement bpMove;
    [SerializeField] HouseSpawner houseSpawn;
    // Start is called before the first frame update
    void Start()
    {
        rulesManager = GameObject.Find("Managers").GetComponent<RulesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (health - 1 >= 0)
        {
            hearts[health - 1].SetActive(false);
            health--;
        }
        else
        {
            rulesManager.enabled = false;
            //bcScroll.enabled = false;
            bpMove.enabled = false;
            houseSpawn.enabled = false;
            //Game Over
            gameOverText[0].text = "Game";
            gameOverText[1].text = "Over";
            gameOverText[2].text = "Please";
            gameOverText[3].text = "Refresh";
        }

    }
}

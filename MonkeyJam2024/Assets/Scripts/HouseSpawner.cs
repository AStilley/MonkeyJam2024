using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    RulesManager rulesManager;
    [SerializeField] GameObject housePrefab;

    float timer = 2f;

    int houseCount = 0;

    bool spawnEnable = false;

    // Start is called before the first frame update
    void Start()
    {
        rulesManager = GameObject.Find("Managers").GetComponent<RulesManager>();
        SetSpawner();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnable)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f) 
            {
                Spawn();
                houseCount++;

                timer = 2f;

                if (houseCount >= 10)
                { 
                    rulesManager.NewRules();
                    houseCount = 0;
                }
            }



        }
    }

    public void SetSpawner()
    {
        spawnEnable = true;
    }

    void Spawn()
    {
        var HouseToMake = Instantiate(housePrefab, new Vector3(8,3,0), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] int points = 0;
    [SerializeField] TMP_Text scoreCounterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = points.ToString();
    }

    public void AddScore(int pointChange)
    {
        points += pointChange;
    }
}

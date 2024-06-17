using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    private Button button;
    private float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            button.enabled = true;
        }
    }

    public void StartCooldown() {
        cooldown = 1f;
        button.enabled = false;
    }
}

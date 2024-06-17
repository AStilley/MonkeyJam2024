using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
        
        if (transform.position.x < -3.292)
        {
            transform.position = StartPosition;
        }
        
    }
}

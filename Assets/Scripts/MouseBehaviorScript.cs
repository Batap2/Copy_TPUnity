using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviorScript : MonoBehaviour
{
    public float speed = 5.0F; // meters per second

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);
    }
}

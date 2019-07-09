using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    Vector3 currentPosition;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity -= new Vector3(Time.deltaTime * speed,0,0);
            transform.position = currentPosition;          
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity -= new Vector3(Time.deltaTime * speed, 0, 0);
            transform.position = currentPosition;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity -= new Vector3(0, 0, Time.deltaTime * speed);
            transform.position = currentPosition;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= new Vector3(0, 0, Time.deltaTime * speed);
            transform.position = currentPosition;
        }
    }

}

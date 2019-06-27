using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    Vector3 currentPosition;

    private void Start()
    {
        currentPosition = transform.position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            currentPosition.x -= Time.deltaTime * speed;
            transform.position = currentPosition;          
        }
        if(Input.GetKey(KeyCode.D))
        {
            currentPosition.x += Time.deltaTime * speed;
            transform.position = currentPosition;
        }
    }

}

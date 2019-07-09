using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    Vector3 currentPosition;

    Rigidbody2D rb;
    Camera mainCamera;
    Vector2 velocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        currentPosition = transform.position;
    }

    private void Update()
    {
        //Vector2 mousePos = mainCamera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //transform.LookAt(mousePos);

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        
        Debug.DrawLine(transform.position, (Vector2)transform.position + velocity,Color.red);

       // if (Input.GetKey(KeyCode.A))
       // {
       //     currentPosition.x -= Time.deltaTime * speed;
       //     transform.position = currentPosition;
       // }
       // if (Input.GetKey(KeyCode.D))
       // {
       //     currentPosition.x += Time.deltaTime * speed;
       //     transform.position = currentPosition;
       // }
       // if (Input.GetKey(KeyCode.S))
       // {
       //     currentPosition.y -= Time.deltaTime * speed;
       //     transform.position = currentPosition;
       // }
       // if (Input.GetKey(KeyCode.W))
       // {
       //     currentPosition.y += Time.deltaTime * speed;
       //     transform.position = currentPosition;
       // }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

}

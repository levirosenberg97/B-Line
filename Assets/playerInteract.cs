using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public Color defaultOutline, newOutline;
    public float speed = 1, offset;

    private Renderer _renderer;
    private MaterialPropertyBlock propBlock;

    private void Awake()
    {
        propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        //propBlock.SetColor("_Color", Color.black);
    }

    private void Update()
    {
            _renderer.GetPropertyBlock(propBlock);

            propBlock.SetColor("_Color", Color.Lerp(defaultOutline, newOutline, (Mathf.Sin(Time.time * speed + offset) + 1) / 2f));

            _renderer.SetPropertyBlock(propBlock);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Hit");
           
        }
    }
}

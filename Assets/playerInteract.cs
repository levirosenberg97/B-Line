using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public Color defaultOutline, newOutline;

    private Renderer _renderer;
    private MaterialPropertyBlock propBlock;

    public List<Dialogue> dialogue;

    private void Awake()
    {
        propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        _renderer.GetPropertyBlock(propBlock);

        propBlock.SetColor("_Color", defaultOutline);
       
        _renderer.SetPropertyBlock(propBlock);
    }

    void TriggerDialogue(string reason)
    {
        GetComponent<DialogueManager>().StartDialogue(dialogue, reason);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(ChangeOutline(newOutline, propBlock.GetColor("_Color")));          
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(gameObject.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(ChangeOutline(defaultOutline, propBlock.GetColor("_Color")));
        }
    }

    IEnumerator ChangeOutline(Color newColor, Color startColor)
    {
        float increment = 0;
        while (propBlock.GetColor("_Color") != newColor)
        {
            _renderer.GetPropertyBlock(propBlock);

            propBlock.SetColor("_Color", Color.Lerp(startColor, newColor, increment));

            increment += .1f;

            _renderer.SetPropertyBlock(propBlock);

            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }
}

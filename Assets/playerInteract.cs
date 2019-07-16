using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public Color defaultOutline, newOutline;

    private Renderer _renderer;
    private MaterialPropertyBlock propBlock;

    public float radius;

    float dis;
    public Transform player;

    public List<Dialogue> dialogue;
    bool clickable;

    private void Awake()
    {
        propBlock = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        _renderer.GetPropertyBlock(propBlock);

        propBlock.SetColor("_Color", defaultOutline);
       
        _renderer.SetPropertyBlock(propBlock);
    }

    float Distance(Vector2 firstPos, Vector2 secPos)
    {
        return dis = Mathf.Sqrt(((secPos.x - firstPos.x) * (secPos.x - firstPos.x)) + ((secPos.y - firstPos.y) * (secPos.y - firstPos.y)));
    }

    private void OnMouseDown()
    {
        if (clickable == true)
        {
            TriggerDialogue("Greeting");
        }
    }

    void TriggerDialogue(string reason)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, reason);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Distance(player.position, transform.position);
            if (dis <= radius)
            {
                StartCoroutine(ChangeOutline(newOutline, propBlock.GetColor("_Color")));
                clickable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TriggerDialogue("Greeting");
                }
                //Debug.Log(dis);
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(ChangeOutline(defaultOutline, propBlock.GetColor("_Color")));
                clickable = false;
                //Debug.Log(dis);
            }
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

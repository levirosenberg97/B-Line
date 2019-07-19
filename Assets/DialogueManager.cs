using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image charPortrait;

    private Queue<DialogueBox> sentences;

    List<Dialogue> dialogueList;

    bool speaking;

    private void Start()
    {
        sentences = new Queue<DialogueBox>();
    }

    public void StartDialogue(List<Dialogue> dialogues, string reason)
    {
        sentences.Clear();

        for(int i = 0; i < dialogues.Count; i++ )
        {
            if(dialogues[i].reason == reason)
            {
                nameText.text = dialogues[i].dialogueBoxes[0].name;

                
                foreach(DialogueBox line in dialogues[i].dialogueBoxes)
                {
                    sentences.Enqueue(line);               
                }
                break;
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueBox line = sentences.Dequeue();
        nameText.text = line.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(line.sentence));
    }

    void EndDialogue()
    {
        Debug.Log("End Talks");
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}

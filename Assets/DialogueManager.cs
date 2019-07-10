using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    List<Dialogue> dialogueList;

    bool speaking;

    public void StartDialogue(List<Dialogue> dialogues, string reason)
    {
        for(int i = 0; i < dialogues.Count; i++)
        {
            if(dialogues[i].reason == reason)
            {
                speaking = true;

                sentences = new Queue<string>();

                dialogueList = dialogues;
                nameText.text = dialogues[i].name;

                sentences.Clear();

                foreach(string sentence in dialogues[i].sentences)
                {
                    sentences.Enqueue(sentence);
                }

                DisplayNextSentence();

                break;
            }
        }
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue()
    {
        speaking = false;
        dialogueList.Remove(dialogueList[0]);
    }

    private void Update()
    {
        if(speaking == true)
        {
            DisplayNextSentence();
        }
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

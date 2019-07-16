using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueBox
{
    public string reason;

    //public bool seen;
    public Image charPortait;
    public string[] names;
    [TextArea(3, 10)]
    public string[] sentences;
}


[System.Serializable]
public class Dialogue
{


    public DialogueBox[] dialogueBoxes;


}

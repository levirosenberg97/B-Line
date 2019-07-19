using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueBox
{
    //public bool seen;
    public Image charPortait;
    public string name;
    [TextArea(3, 10)]
    public string sentence;
}


[System.Serializable]
public class Dialogue
{
    public string reason;
    public DialogueBox[] dialogueBoxes;
}

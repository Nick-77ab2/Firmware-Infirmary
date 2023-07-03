using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusStartController : MonoBehaviour
{
    public Button startButton;
    public VirusController controller;
    public NewDialogueScript dialogueScript;
    public bool dialogueDone = false;

    void Update()
    {
        if (!dialogueDone)
        {
            dialogueScript = FindObjectOfType<NewDialogueScript>();
            if (dialogueScript.next) 
            {
                startButton.gameObject.SetActive(true);
                dialogueDone = true;
            }
        }
        else
        {
            if (controller.isDone)
            {
                controller.gameObject.SetActive(false);
            }
        }
    }
}

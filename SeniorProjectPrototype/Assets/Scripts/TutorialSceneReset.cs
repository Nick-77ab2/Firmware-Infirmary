using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneReset : MonoBehaviour
{

    [SerializeField]
    private TextAsset tutDialogue;
    [SerializeField]
    private Canvas tutCanvas;
    [SerializeField]
    private GameObject tutExitButton;
    [SerializeField]
    private MiniGameManager miniMan;
    [SerializeField]
    private MenuCameraController camCon;
    [SerializeField]
    private GameObject dialogueScriptObj;
    [SerializeField]
    private DialogueManager dialogueManager;

    private GameObject dialogueScriptO;
    private NewDialogueScript dialogueScript;
    public RingCameraDialogue cameraDialogueScript;

    public void TutorialReset(){
        camCon.game2Camera = miniMan.gameCamera2;
        camCon.game2Controller = miniMan.gameController2;
        camCon.game2Ui = miniMan.gameUi2;
        Destroy(dialogueScriptO);
        dialogueScriptO = Instantiate(dialogueScriptObj);
        dialogueScript = dialogueScriptO.GetComponent<NewDialogueScript>();
        dialogueScript.changeInkAsset(tutDialogue);
        dialogueScript.changeCanvas(tutCanvas);
        dialogueScript.gameObject.SetActive(false);
        dialogueScript.changeExitButton(tutExitButton);
        cameraDialogueScript.CustomAwake();
        Debug.Log("reseted");
    }
}

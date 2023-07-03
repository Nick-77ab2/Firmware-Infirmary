using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject intercomImageToSet;
    [SerializeField]
    private Sprite intercomSprite;
    [SerializeField]
    private TextAsset intercomDialogue;
    [SerializeField]
    private Canvas intercomCanvas;
    [SerializeField]
    private GameObject doorBellExitButton;
    [SerializeField]
    private TextAsset mg1Dialogue;
    [SerializeField]
    private Canvas mg1Canvas;
    [SerializeField]
    private GameObject mg1ExitButton;
    [SerializeField]
    private TextAsset mg2Dialogue;
    [SerializeField]
    private Canvas mg2Canvas;
    [SerializeField]
    private GameObject mg2ExitButton;
    [SerializeField]
    private GameObject dialogueScriptObj;
    [SerializeField]
    private GameObject ringDialogueScriptObj;
    [SerializeField]
    private TextAsset sprayDialogue;
    [SerializeField]
    private TextAsset upgradesDialogue;
    [SerializeField]
    private TextAsset virusDialogue;
    [SerializeField]
    private MiniGameManager miniMan;
    [SerializeField]
    private MenuCameraController camCon;

    private GameObject dialogueScriptO;
    private NewDialogueScript dialogueScript;

    private GameObject ringDialogueScriptO;
    public RingCameraDialogue cameraDialogueScript;

    private int mood = 0;
    private int nextMood = 0;
    private bool success;
    private string goToNext;
    public string color = "";

    void Awake()
    {
        GameManager.StateChanged += GameManagerOnStateChanged;
    }

    void OnDestroy()
    {
        GameManager.StateChanged -= GameManagerOnStateChanged;
    }

    private void Update()
    {
        if (GameManager.instance.DayState == GameManager.DayGameState.Day7 && GameManager.instance.State == GameManager.GameState.MiniGame1)
        {
            if (dialogueScript.color != null)
            {
                Debug.Log(dialogueScript.color);
                color = dialogueScript.color;
                GameManager.instance.color = color;
            }
        }
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.AtDoor)
        {
            if (GameManager.instance.DayState == GameManager.DayGameState.Day2)
            {
                cameraDialogueScript.SetMoodIntercom(GameManager.instance.moods["Camilla"]);
            }
            doorBellExitButton.SetActive(false);

            intercomImageToSet.GetComponent<Image>().sprite = intercomSprite;
            cameraDialogueScript.gameObject.SetActive(false);
            cameraDialogueScript.changeInkAsset(intercomDialogue);
            cameraDialogueScript.changeCanvas(intercomCanvas);
            cameraDialogueScript.changeExitButton(doorBellExitButton);
            cameraDialogueScript.CustomAwake();
        }
        else if (state == GameManager.GameState.MovingToPod)
        {
            mood = cameraDialogueScript.mood;
            nextMood = cameraDialogueScript.nextMood;
        }
        else if (state == GameManager.GameState.MiniGame1)
        {
            Destroy(dialogueScriptO);
            dialogueScriptO = Instantiate(dialogueScriptObj);
            dialogueScript = dialogueScriptO.GetComponent<NewDialogueScript>();
            dialogueScript.changeInkAsset(mg1Dialogue);
            dialogueScript.changeCanvas(mg1Canvas);
            dialogueScript.gameObject.SetActive(false);
            dialogueScript.changeExitButton(mg1ExitButton);

            if (GameManager.instance.DayState == GameManager.DayGameState.Day10)
            {
                if (GameManager.instance.ypz == 1)
                {
                    dialogueScript.YPZ = "Alive";
                }
                else
                {
                    dialogueScript.YPZ = "Dead";
                }
            }
            dialogueScript.SetMood(mood);
            dialogueScript.SetNextMood(nextMood);
        }
        else if (state == GameManager.GameState.MiniGame2 && SceneManager.GetActiveScene().name == "Isabella_Enviro")
        {
            if (GameManager.instance.DayState == GameManager.DayGameState.Day2) 
            {
                success = dialogueScript.isSuccess;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day4)
            {
                goToNext = dialogueScript.goToNext;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
            {
                success = dialogueScript.isSuccess;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day6)
            {
                goToNext = dialogueScript.goToNext;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day10)
            {
                goToNext = dialogueScript.goToNext;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day11)
            {
                goToNext = dialogueScript.goToNext;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day12)
            {
                success = dialogueScript.isSuccess;
            }
            mood = dialogueScript.mood;
            nextMood = dialogueScript.nextMood;

            Destroy(dialogueScriptO);
            dialogueScriptO = Instantiate(dialogueScriptObj);
            dialogueScript = dialogueScriptO.GetComponent<NewDialogueScript>();
            dialogueScript.changeInkAsset(mg2Dialogue);
            dialogueScript.changeCanvas(mg2Canvas);
            dialogueScript.gameObject.SetActive(false);
            dialogueScript.changeExitButton(mg2ExitButton);

            if (GameManager.instance.DayState == GameManager.DayGameState.Day1)
            {
                dialogueScript.SetGoToNext(null);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day2)
            {
                dialogueScript.SetPreviousSuccess(success);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day4)
            {
                dialogueScript.SetGoToNext(goToNext);
                Debug.Log(goToNext);
                Debug.Log(dialogueScript.goToNext);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
            {
                dialogueScript.SetPreviousSuccess(success);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day6)
            {
                dialogueScript.SetGoToNext(goToNext);
                Debug.Log(goToNext);
                Debug.Log(dialogueScript.goToNext);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day10)
            {
                dialogueScript.SetGoToNext(goToNext);
                Debug.Log(goToNext);
                Debug.Log(dialogueScript.goToNext);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day11)
            {
                dialogueScript.SetGoToNext(goToNext);
                Debug.Log(goToNext);
                Debug.Log(dialogueScript.goToNext);
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day12)
            {
                dialogueScript.SetPreviousSuccess(success);
                GameManager.instance.finalSuccess = success;
            }
            dialogueScript.SetMood(mood);
            dialogueScript.SetNextMood(nextMood);
        }
        else if (state == GameManager.GameState.Leaving)
        {
            dialogueScript.gameObject.SetActive(false);
            mood = dialogueScript.mood;
            nextMood = dialogueScript.nextMood;

            if (GameManager.instance.DayState == GameManager.DayGameState.Day1 && GameManager.instance.isTutorial == false)
            {
                GameManager.instance.moods["Tusk"] = mood;
                GameManager.instance.moods["Camilla"] = nextMood;
            }

            if (GameManager.instance.DayState == GameManager.DayGameState.Day2)
            {
                GameManager.instance.moods["Camilla"] = mood;
            }
            if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
            {
                Debug.Log(dialogueScript.YPZ);
                if (dialogueScript.YPZ == "Alive")
                {
                    GameManager.instance.ypz = 1;
                }
                else
                {
                    GameManager.instance.ypz = 0;
                }
            }
        }
    }

    public void setCameraDialogueActive()
    {
        cameraDialogueScript.gameObject.SetActive(true);
        cameraDialogueScript.canStart = true;
    }

    public void setDialogueActive()
    {
        dialogueScript.gameObject.SetActive(true);
    }

    public void changeDayScripts(TextAsset intercomS, TextAsset mgS1, TextAsset mgS2, Sprite sprite)
    {
        intercomDialogue = intercomS;
        mg1Dialogue = mgS1;
        mg2Dialogue = mgS2;
        intercomSprite = sprite;
        Debug.Log("Dialogue changed.");
    }

    public void changeMiniGamesCanvasAndExit(Canvas canvas1, GameObject exit1, Canvas canvas2, GameObject exit2)
    {
        mg1Canvas = canvas1;
        mg1ExitButton = exit1;
        mg2Canvas = canvas2;
        mg2ExitButton = exit2;
        Debug.Log("Canvas changed.");
    }

    public void SetTutorialSpray(){
        camCon.game1Camera = miniMan.gameCamera1;
        camCon.game1Controller = miniMan.gameController1;
        camCon.game1Ui = miniMan.gameUi1;
        camCon.game2Camera = miniMan.gameCamera1v2;
        camCon.game2Controller = miniMan.gameController1v2;
        camCon.game2Ui = miniMan.gameUi1v2;
        Destroy(dialogueScriptO);
        dialogueScriptO = Instantiate(dialogueScriptObj);
        dialogueScript = dialogueScriptO.GetComponent<NewDialogueScript>();
        dialogueScript.changeInkAsset(sprayDialogue);
        dialogueScript.changeCanvas(miniMan.canvas1v2);
        dialogueScript.gameObject.SetActive(false);
        dialogueScript.changeExitButton(miniMan.exit1v2);
        cameraDialogueScript.CustomAwake();
        Debug.Log("reseted");
    }

    public void SetTutorialUpgrades(){
        camCon.game1Camera = miniMan.gameCamera1v2;
        camCon.game1Controller = miniMan.gameController1v2;
        camCon.game1Ui = miniMan.gameUi1v2;
        camCon.game2Camera = miniMan.gameCamera2;
        camCon.game2Controller = miniMan.gameController2;
        camCon.game2Ui = miniMan.gameUi2;
        Destroy(dialogueScriptO);
        dialogueScriptO = Instantiate(dialogueScriptObj);
        dialogueScript = dialogueScriptO.GetComponent<NewDialogueScript>();
        dialogueScript.changeInkAsset(upgradesDialogue);
        dialogueScript.changeCanvas(miniMan.canvas2);
        dialogueScript.gameObject.SetActive(false);
        dialogueScript.changeExitButton(miniMan.exit2);
        cameraDialogueScript.CustomAwake();
        Debug.Log("reseted");
    }

    public void SetTutorialVirus(){
        camCon.game1Camera = miniMan.gameCamera2;
        camCon.game1Controller = miniMan.gameController2;
        camCon.game1Ui = miniMan.gameUi2;
        camCon.game2Camera = miniMan.gameCamera5v2;
        camCon.game2Controller = miniMan.gameController5v2;
        camCon.game2Ui = miniMan.gameUi5v2;
        Destroy(dialogueScriptO);
        dialogueScriptO = Instantiate(dialogueScriptObj);
        dialogueScript = dialogueScriptO.GetComponent<NewDialogueScript>();
        dialogueScript.changeInkAsset(virusDialogue);
        dialogueScript.changeCanvas(miniMan.canvas5v2);
        dialogueScript.gameObject.SetActive(false);
        dialogueScript.changeExitButton(miniMan.exit5v2);
        cameraDialogueScript.CustomAwake();
        Debug.Log("reseted");
    }
}
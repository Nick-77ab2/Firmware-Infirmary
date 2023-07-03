using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public DayGameState DayState;
    public GameState State;

    public int dayNum = 1;

    public static event Action<DayGameState> DayStateChanged;
    public static event Action<GameState> StateChanged;
    
    public Dictionary<int, DayGameState> dayStates = new Dictionary<int, DayGameState>();
    public Dictionary<string, int> moods = new Dictionary<string, int>();
    public int ypz;
    public string color;
    public bool finalSuccess;

    public FadeToBlack fade;
    public GameObject overlay;
    public MenuCameraController menuCameraController;
    public MenuCameraController menuCameraController2;
    public CameraTrigger cameraTrigger;
    private float startX = -4.63f, startY = 0.056f, startZ = 9.583f, startRotationX = 0f, startRotationY = 0f;
    public GameObject playerBody;
    public GameObject playerCam;
    public Transform orientation;

    public bool isTutorial;
    private NewDialogueScript script;

    private void Awake()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        dayStates.Add(1, DayGameState.Day1);
        dayStates.Add(2, DayGameState.Day2);
        dayStates.Add(3, DayGameState.Day3);
        dayStates.Add(4, DayGameState.Day4);
        dayStates.Add(5, DayGameState.Day5);
        dayStates.Add(6, DayGameState.Day6);
        dayStates.Add(7, DayGameState.Day7);
        dayStates.Add(8, DayGameState.Day8);
        dayStates.Add(9, DayGameState.Day9);
        dayStates.Add(10, DayGameState.Day10);
        dayStates.Add(11, DayGameState.Day11);
        dayStates.Add(12, DayGameState.Day12);
        dayStates.Add(13, DayGameState.Day13);
        dayStates.Add(14, DayGameState.Day14);
        instance = this;

        moods.Add("Tusk", 0);
        moods.Add("Camilla", 0);

        DayReset.Load();
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Init:
                Debug.Log("Init");
                playerBody.transform.localPosition = new Vector3(startX, startY, startZ);
                playerCam.transform.rotation = Quaternion.Euler(startRotationX, startRotationY, 0);
                orientation.rotation = Quaternion.Euler(0, startRotationY, 0);
                orientation.parent.rotation = Quaternion.Euler(0, startRotationY, 0);
                UpdateGameState(GameManager.GameState.DayBegin);
                break;
            case GameState.DayBegin:
                Debug.Log("DayBegin");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.AtDoor:
                Debug.Log("AtDoor");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.MovingToPod:
                Debug.Log("MovingToPod");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.InPod:
                Debug.Log("InPod");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.MiniGame1:
                Debug.Log("MiniGame1");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.MiniGame2:
                Debug.Log("MiniGame2");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.DoneMiniGames:
                Debug.Log("DoneMiniGames");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.Leaving:
                Debug.Log("Leaving");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.DaySummary:
                Debug.Log("DaySummary");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            case GameState.DayEnd:
                Debug.Log("DayEnd");
                if(SceneManager.GetActiveScene().name == "Isabella_Enviro"){
                    DayReset.Save();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        StateChanged(newState);
    }

    public void UpdateDayGameState(DayGameState newState)
    {
        DayState = newState;

        switch (newState)
        {
            case DayGameState.Day1:
                Debug.Log("Day1");
                break;
            case DayGameState.Day2:
                Debug.Log("Day2");
                break;
            case DayGameState.Day3:
                Debug.Log("Day3");
                break;
            case DayGameState.Day4:
                Debug.Log("Day4");
                break;
            case DayGameState.Day5:
                Debug.Log("Day5");
                break;
            case DayGameState.Day6:
                Debug.Log("Day6");
                break;
            case DayGameState.Day7:
                Debug.Log("Day7");
                break;
            case DayGameState.Day8:
                Debug.Log("Day8");
                break;
            case DayGameState.Day9:
                Debug.Log("Day9");
                break;
            case DayGameState.Day10:
                Debug.Log("Day10");
                break;
            case DayGameState.Day11:
                Debug.Log("Day11");
                break;
            case DayGameState.Day12:
                Debug.Log("Day12");
                break;
            case DayGameState.Day13:
                Debug.Log("Day13");
                break;
            case DayGameState.Day14:
                Debug.Log("Day14");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        DayStateChanged(newState);
    }

    public void FailDay()
    {
        if(isTutorial){
            script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
            script.isFail = true;
        }else{
            StartCoroutine(FailDayCoroutine());
        }
    }

    public IEnumerator FailDayCoroutine()
    {
        menuCameraController2.changeToGame2();
        cameraTrigger.close2DCam();
        overlay.SetActive(true);
        //overlay.transform.Find("DirectionalCanvas-1").gameObject.SetActive(false);
        yield return StartCoroutine(fade.FailFadeCoroutine());
        yield return new WaitForSeconds(4f);

        ReloadScene rl = new ReloadScene();
        rl.reloadScene();
        //overlay.transform.Find("DirectionalCanvas-1").gameObject.SetActive(false);
    }

    public GameState getGameState()
    {
        return State;
    }

    public enum GameState
    {
        Init,
        DayBegin,
        AtDoor,
        MovingToPod,
        InPod,
        MiniGame1,
        MiniGame2,
        DoneMiniGames,
        Leaving,
        DaySummary,
        DayEnd
    }

    public enum DayGameState
    {
        Day1,
        Day2,
        Day3,
        Day4,
        Day5,
        Day6,
        Day7,
        Day8,
        Day9,
        Day10,
        Day11,
        Day12,
        Day13,
        Day14
    }
}
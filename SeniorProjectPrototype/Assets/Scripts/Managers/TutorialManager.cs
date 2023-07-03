using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject tut1;
    public GameObject tut2;
    public GameObject tut3;
    public GameObject tut4;
    public GameObject tut5;
    public GameObject tut1C;
    public GameObject tut2C;
    public GameObject tut3C;
    public GameObject tut4C;
    public GameObject tut5C;

    void Awake()
    {
        GameManager.StateChanged += GameManagerOnStateChanged;
    }

    void OnDestroy()
    {
        GameManager.StateChanged -= GameManagerOnStateChanged;
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if(state == GameManager.GameState.MovingToPod && GameManager.instance.DayState == GameManager.DayGameState.Day1 && SceneManager.GetActiveScene().name == "TutorialFromScrath"){
            tut1.SetActive(false);
            tut2.SetActive(false);
            tut3.SetActive(false);
            tut4.SetActive(true);
            tut1C.SetActive(false);
            tut2C.SetActive(false);
            tut3C.SetActive(false);
            tut4C.SetActive(true);
        }
        if (state == GameManager.GameState.Leaving && GameManager.instance.DayState == GameManager.DayGameState.Day1 && SceneManager.GetActiveScene().name == "TutorialFromScrath"){
            tut4.SetActive(false);
            tut4C.SetActive(false);
            tut5.SetActive(true);
            tut5C.SetActive(true);
        }
        if (state == GameManager.GameState.DaySummary && GameManager.instance.DayState == GameManager.DayGameState.Day1 && SceneManager.GetActiveScene().name == "TutorialFromScrath")
        {
            tut1.SetActive(false);
            tut2.SetActive(false);
            tut3.SetActive(false);
            tut4.SetActive(false);
            tut1C.SetActive(false);
            tut2C.SetActive(false);
            tut3C.SetActive(false);
            tut4C.SetActive(false);
        }
    }
}

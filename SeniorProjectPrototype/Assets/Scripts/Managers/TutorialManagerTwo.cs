using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManagerTwo : MonoBehaviour
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
        GameManager.DayStateChanged += GameManagerOnStateChanged;
    }

    void OnDestroy()
    {
        GameManager.DayStateChanged -= GameManagerOnStateChanged;
    }

    private void GameManagerOnStateChanged(GameManager.DayGameState state)
    {
        if (state != GameManager.DayGameState.Day1)
        {
            tut1.SetActive(false);
            tut2.SetActive(false);
            tut3.SetActive(false);
            tut4.SetActive(false);
            tut5.SetActive(false);
            tut1C.SetActive(false);
            tut2C.SetActive(false);
            tut3C.SetActive(false);
            tut4C.SetActive(false);
            tut5C.SetActive(false);
        }
    }
}

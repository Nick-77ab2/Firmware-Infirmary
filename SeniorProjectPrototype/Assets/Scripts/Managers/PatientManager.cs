using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class PatientManager : MonoBehaviour
{
    public GameObject Patient;
    public GameObject Zuri;
    public GameObject Light;
    public Material mat1;
    public Material mat2;
    public Sprite spriteDay1;
    public Sprite spriteDay2;
    public Sprite spriteDay3;
    public Sprite spriteDay4;
    public Sprite spriteDay5;
    public Sprite spriteDay6;
    public Sprite spriteDay71;
    public Sprite spriteDay72;
    public Sprite spriteDay8;
    public Sprite spriteDay9;
    public Sprite spriteDay10;
    public Sprite spriteDay11;
    public Sprite spriteDay12;

    void Awake()
    {
        GameManager.StateChanged += GameManagerOnStateChanged;
    }

    void OnDestroy()
    {
        GameManager.StateChanged -= GameManagerOnStateChanged;
    }

    void Start()
    {
        Patient.SetActive(false);
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if(state == GameManager.GameState.DayBegin){
            if (GameManager.instance.DayState == GameManager.DayGameState.Day1)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay1;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day2)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay2;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day3)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay3;
            }
            else if(GameManager.instance.DayState == GameManager.DayGameState.Day4)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay4;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay5;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day6)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay6;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day7)
            {
                Debug.Log("YPZ val:" + GameManager.instance.ypz);
                if (GameManager.instance.ypz == 0)
                {
                    Patient.GetComponent<SpriteRenderer>().sprite = spriteDay71;
                }
                else
                {
                    Patient.GetComponent<SpriteRenderer>().sprite = spriteDay72;
                }
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day8)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay8;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day9)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay9;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day10)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay10;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day11)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay11;
            }
            else if (GameManager.instance.DayState == GameManager.DayGameState.Day12)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay12;
            }
        }
        else if (state == GameManager.GameState.MovingToPod)
        {
            if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
            {
                Zuri.SetActive(true);
            }
            Patient.SetActive(true);
            Light.GetComponent<MeshRenderer>().sharedMaterial = mat2;
        }
        else if (state == GameManager.GameState.DaySummary)
        {
            if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
            {
                Zuri.SetActive(false);
            }
            Patient.SetActive(false);
            Light.GetComponent<MeshRenderer>().sharedMaterial = mat1;
        }
    }

    private void GameManagerOnDayStateChanged(GameManager.DayGameState state)
    {
        if (state == GameManager.DayGameState.Day1)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay1;
        }
        else if (state == GameManager.DayGameState.Day2)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay2;
        }
        else if (state == GameManager.DayGameState.Day3)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay3;
        }
        else if(state == GameManager.DayGameState.Day4)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay4;
        }
        else if (state == GameManager.DayGameState.Day5)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay5;
        }
        else if (state == GameManager.DayGameState.Day6)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay6;
        }
        else if (state == GameManager.DayGameState.Day7)
        {
            Debug.Log("YPZ val:" + GameManager.instance.ypz);
            if (GameManager.instance.ypz == 0)
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay71;
            }
            else
            {
                Patient.GetComponent<SpriteRenderer>().sprite = spriteDay72;
            }
        }
        else if (state == GameManager.DayGameState.Day8)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay8;
        }
        else if (state == GameManager.DayGameState.Day9)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay9;
        }
        else if (state == GameManager.DayGameState.Day10)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay10;
        }
        else if (state == GameManager.DayGameState.Day11)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay11;
        }
        else if (state == GameManager.DayGameState.Day12)
        {
            Patient.GetComponent<SpriteRenderer>().sprite = spriteDay12;
        }
    }
}

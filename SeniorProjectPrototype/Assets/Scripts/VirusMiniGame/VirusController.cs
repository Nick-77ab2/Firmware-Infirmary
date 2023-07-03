using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class VirusController : MonoBehaviour
{
    [SerializeField] private float startBpm1;
    [SerializeField] private float bpm1;
    [SerializeField] private float highBpm1;
    [SerializeField] private float lowBpm1;
    [SerializeField] private float startBpm2;
    [SerializeField] private float bpm2;
    [SerializeField] private float highBpm2;
    [SerializeField] private float lowBpm2;
    [SerializeField] private float startBpm3;
    [SerializeField] private float bpm3;
    [SerializeField] private float highBpm3;
    [SerializeField] private float lowBpm3;
    [SerializeField] private SineWave s1;
    [SerializeField] private SineWave s2;
    [SerializeField] private SineWave s3;
    [SerializeField] private TextMeshProUGUI t1;
    [SerializeField] private TextMeshProUGUI t2;
    [SerializeField] private TextMeshProUGUI t3;
    [SerializeField] private TextMeshProUGUI timerWin;
    [SerializeField] private TextMeshProUGUI timerLose;
    public float winTime = 20f;
    public float timeRemainingWin = 20f;
    public bool timerIsRunningWin = false;
    public float loseTime = 5f;
    public float timeRemainingLose = 5f;
    public bool timerIsRunningLose = false;
    public float damageTime = 1.5f;
    public float timeRemainingDamage = 1.5f;
    private NewDialogueScript script;
    public bool isDone = false;

    // Update is called once per frame
    void Update()
    {
        timerWin.text = "Stabilizing Rate: " + Mathf.Ceil(timeRemainingWin).ToString();
        timerLose.text = "System Shutdown: " + Mathf.Ceil(timeRemainingLose).ToString();

        if (!isDone)
        {
            if (bpm1 < 0)
            {
                bpm1 = 0;
            }

            if (bpm2 < 0)
            {
                bpm2 = 0;
            }

            if (bpm3 < 0)
            {
                bpm3 = 0;
            }


            t1.text = bpm1.ToString();
            t2.text = bpm2.ToString();
            t3.text = bpm3.ToString();

            if (bpm1 > highBpm1) 
            {
                t1.color = Color.red;
            }
            else if (bpm1 < lowBpm1)
            {
                t1.color = Color.blue;
            }
            else
            {
                t1.color = Color.black;
            }

            if (bpm2 > highBpm2)
            {
                t2.color = Color.red;
            }
            else if (bpm2 < lowBpm2)
            {
                t2.color = Color.blue;
            }
            else
            {
                t2.color = Color.black;
            }

            if (bpm3 > highBpm3)
            {
                t3.color = Color.red;
            }
            else if (bpm3 < lowBpm3)
            {
                t3.color = Color.blue;
            }
            else
            {
                t3.color = Color.black;
            }

            s1.amplitude = (bpm1 / startBpm1) * s1.startAmplitude;
            s2.amplitude = (bpm2 / startBpm2) * s2.startAmplitude;
            s3.amplitude = (bpm3 / startBpm3) * s3.startAmplitude;

            s1.movementSpeed = (bpm1 / startBpm1) * s1.startMovementSpeed;
            s2.movementSpeed = (bpm2 / startBpm2) * s2.startMovementSpeed;
            s3.movementSpeed = (bpm3 / startBpm3) * s3.startMovementSpeed;

            if (isFailing())
            {
                timerIsRunningWin = false;
                //timeRemainingWin = winTime;
                if (timerIsRunningLose)
                {
                    if (timeRemainingLose > 0)
                    {
                        if((timeRemainingLose - Time.deltaTime)<0){
                            timeRemainingLose = 0;
                        }
                        else{
                            timeRemainingLose -= Time.deltaTime;
                        }
                    }
                    else
                    {
                        Debug.Log("Virus game is returning fail.");
                        script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
                        script.isFail = true;
                        isDone = true;
                        if (GameManager.instance.DayState != GameManager.DayGameState.Day5)
                        {
                            GameManager.instance.FailDay();
                        }
                    }
                }
                else
                {
                    timerIsRunningLose = true;
                    timeRemainingLose = loseTime;
                }
            }
            else
            {
                timerIsRunningLose = false;
                timeRemainingLose = loseTime;
                if (timerIsRunningWin)
                {
                    if (timeRemainingWin > 0)
                    {
                        if((timeRemainingWin - Time.deltaTime)<0){
                            timeRemainingWin = 0;
                        }
                        else{
                            timeRemainingWin -= Time.deltaTime;
                        }
                    }
                    else
                    {
                        Debug.Log("Virus game is returning success.");
                        script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
                        script.isSuccess = true;
                        isDone = true;
                    }
                }
                else
                {
                    timerIsRunningWin = true;
                    //timeRemainingWin = winTime;
                }
            }

            if (timeRemainingDamage > 0)
            {
                timeRemainingDamage -= Time.deltaTime;
            }
            else
            {
                takeDamage();
                timeRemainingDamage = damageTime;
            }
        }
    }

    void takeDamage()
    {
        AkSoundEngine.PostEvent("Play_Error", this.gameObject);
        bpm1 -= Random.Range(0, 11);
        bpm2 -= Random.Range(0, 11);
        bpm3 -= Random.Range(0, 11);
    }

    bool isFailing()
    { 
        if(bpm1 > highBpm1 || bpm1 < lowBpm1
            || bpm2 > highBpm2 || bpm2 < lowBpm2
            || bpm3 > highBpm3 || bpm3 < lowBpm3) 
        {
            return true;
        }

        return false;
    }

    public void push1()
    {
        bpm1 += 6f;
        bpm2 += 2f;
        bpm3 -= 1f;
    }

    public void push2()
    {
        bpm1 -= 1f;
        bpm2 += 2f;
        bpm3 += 6f;
    }
    public void push3()
    {
        bpm1 -= 3f;
        bpm2 += 3f;
        bpm3 -= 3f;
    }

    IEnumerator playBeep()
    {
        yield return new WaitForSeconds(3);
        AkSoundEngine.PostEvent("Play_HeartRateBeep", this.gameObject);
    }
}
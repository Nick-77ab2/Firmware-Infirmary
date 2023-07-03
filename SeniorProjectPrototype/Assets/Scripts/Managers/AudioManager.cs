using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private uint musicEventId;
    [SerializeField]
    private AK.Wwise.Event musicEvent;
    [SerializeField]
    private string curAudioEvent;
    [SerializeField]
    private string newAudioEvent;
    [SerializeField]
    private AK.Wwise.State state1;
    [SerializeField]
    public bool isDayStart = true;
    public bool once=false;
    public bool fadeToBlack = false;

    public void SetState(string state)
    {
        newAudioEvent = state;
        AkSoundEngine.SetState("Music", newAudioEvent);
        curAudioEvent = newAudioEvent;
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Start_Menu")
        {
            musicEventId = musicEvent.Post(gameObject);
        }
        isDayStart=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Start_Menu")
        {
            if (GameManager.instance.DayState == GameManager.DayGameState.Day6)
            {
                SetState("Hollow");
            }
            if (GameManager.instance.State == GameManager.GameState.DayBegin && isDayStart)
            {
                Debug.LogWarning("Testing, this should be played.");
                PlayDayStart();
                SwitchDayState();
                Debug.Log(GameManager.instance.State);
                StartCoroutine(PlayMusic());
            }
            if (GameManager.instance.State == GameManager.GameState.AtDoor)
            {
                if(!once){
                    SwitchDayState();
                    once=true;
                }
            }
            if (GameManager.instance.State == GameManager.GameState.DayEnd && GameManager.instance.DayState != GameManager.DayGameState.Day12)
            {
                AkSoundEngine.StopPlayingID(musicEventId);
                once=false;
            }
            if (fadeToBlack)
            {
                fadeToBlack=false;
                SetState("MainMenu");
                StartCoroutine(PlayMusic());
            }
        }
    }

    public void PlayDayStart()
    {
        AkSoundEngine.PostEvent("Play_DayStart", this.gameObject);
    }

    public void SwitchDayState()
    {
        isDayStart = !isDayStart;
    }
    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(3);
        musicEventId = musicEvent.Post(gameObject);
        AkSoundEngine.SetState("Music", curAudioEvent);
    }
    public void StopMusic(){
        Debug.LogWarning(musicEventId);
        AkSoundEngine.StopPlayingID(musicEventId, 2000);
    }
}

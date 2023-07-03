using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

public class OpenSignController : Interactable
{
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject npc2;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject openOtherLight;
    [SerializeField] private GameObject openOtherLight1;


    bool isInteractable;

    // Material of object a.k.a. Open sign material
    public Material emissionMat;
    // setable Emission level editable in scene in the shader within the material
    public float emissionLevel;
    // max value of the emission level
    public float maxEmission;
    public GameObject off;
    public GameObject on;
    [SerializeField] private GameObject sign;

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
        if (state == GameManager.GameState.DayBegin)
        {
            SetIsInteractable(true);
        }
        else if (state == GameManager.GameState.AtDoor)
        {
            SetIsInteractable(false);
        }
        else if (state == GameManager.GameState.MovingToPod)
        {
            NPCLeave();
        }
        else if (state == GameManager.GameState.DayEnd) 
        {
            MaterialChange();
        }
    }

    void Start()
    {
        isInteractable = true;
        emissionLevel = 0;
        //using the property name of the emission level dictated by the shader graph, sets the value to 0 on start
        emissionMat.SetFloat("_Emission_Strength", emissionLevel);
    }

    public override void Interact()
    {
        if (isInteractable)
        {
            LightEnabled();
            GameManager.instance.UpdateGameState(GameManager.GameState.AtDoor);
            MaterialChange();
            NPCShowUP();
        }
    }

    public void LightEnabled(){
        off.SetActive(false);
        on.SetActive(true);
        openOtherLight.SetActive(true);
        openOtherLight1.SetActive(true);
    }

    public void LightDisabled(){
        on.SetActive(false);
        off.SetActive(true);
        openOtherLight.SetActive(false);
        openOtherLight1.SetActive(false);
    }

    public override void SetIsInteractable(bool value)
    {
        isInteractable = value;
    }

    public void MaterialChange()
    {
        if (emissionLevel < maxEmission)
        {
            emissionLevel = maxEmission;
            emissionMat.SetFloat("_Emission_Strength", emissionLevel);
        }
        else {
            emissionLevel = 0;
            emissionMat.SetFloat("_Emission_Strength", emissionLevel);
        }
    }

    public void NPCShowUP()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        if (GameManager.instance.DayState == GameManager.DayGameState.Day5) 
        {
            npc2.SetActive(true);
        }
        npc.SetActive(true);
        dialogue.SetActive(true);
        dialogueManager.setCameraDialogueActive();
        AkSoundEngine.PostEvent("Play_Doorbell", this.gameObject);
    }

    public void NPCLeave()
    {
        npc.SetActive(false);
        if (GameManager.instance.DayState == GameManager.DayGameState.Day5)
        {
            npc2.SetActive(false);
        }
        dialogue.SetActive(false);
    }
}

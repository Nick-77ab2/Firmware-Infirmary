using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaySummaryTrigger : Interactable
{
    private bool isInteractable;
    [SerializeField] private GameObject computer;
    public override void Interact()
    {
        if (GameManager.instance.State == GameManager.GameState.DaySummary && isInteractable)
        {
            try{
                GameObject.Find("DirectonalCanvas-5").SetActive(false);
            }
            catch{
                Debug.Log("It's already disabled");
            }
            ChangeStateToEndDay();
            SetIsInteractable(false);
            computer.SetActive(false);
        }
    }

    public override void SetIsInteractable(bool value)
    {
        isInteractable = value;
    }

    public void ChangeStateToEndDay()
    {
        if (GameManager.instance.State == GameManager.GameState.DaySummary)
        {
            if (GameManager.instance.DayState != GameManager.DayGameState.Day12 && SceneManager.GetActiveScene().name != "TutorialFromScrath")
            {
                AkSoundEngine.PostEvent("Play_DayEnd", this.gameObject);
            }
            GameManager.instance.UpdateGameState(GameManager.GameState.DayEnd);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EoDManager : MonoBehaviour
{
    [SerializeField] private GameObject computer;
    [SerializeField] private DaySummaryTrigger daySummaryTrigger;
    public float FullScreenOrthographicSize;

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
        if (state == GameManager.GameState.DaySummary)
        {
            computer.SetActive(true);
            daySummaryTrigger.SetIsInteractable(true);
        }
    }
}

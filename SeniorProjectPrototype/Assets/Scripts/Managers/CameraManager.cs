using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class CameraManager : MonoBehaviour
{
    public CameraTrigger doorbellCamera;
    public CameraTrigger podCamera;

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
        doorbellCamera.SetIsInteractable(false);
        podCamera.SetIsInteractable(false);
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.AtDoor)
        {
            doorbellCamera.enableChangable();
            doorbellCamera.SetIsInteractable(true);
        }
        else if(state == GameManager.GameState.MovingToPod)
        {
            doorbellCamera.SetIsInteractable(false);
            podCamera.SetIsInteractable(true);
        }
        else if (state == GameManager.GameState.Leaving) 
        {
            podCamera.SetIsInteractable(false);
        }
    }
}

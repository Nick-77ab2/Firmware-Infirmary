using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateManager : MonoBehaviour
{
    public NewDialogueScript dialogueScript;

    public void ChangeStateToMovingToPod()
    {
        if (GameManager.instance.State == GameManager.GameState.AtDoor)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.MovingToPod);
        }
    }

    public void ChangeStateToMiniGame1()
    {
        if (GameManager.instance.State == GameManager.GameState.InPod)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.MiniGame1);
        }
    }

    public void ChangeStateToMiniGame2()
    {
        if (GameManager.instance.State == GameManager.GameState.MiniGame1)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.MiniGame2);
        }
    }

    public void ChangeStateToLeaving()
    {
        if (GameManager.instance.State == GameManager.GameState.MiniGame2)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.Leaving);
        }
    }
}

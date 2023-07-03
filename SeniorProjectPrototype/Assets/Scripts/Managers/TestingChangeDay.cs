using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingChangeDay : Interactable
{
    override public void Interact()
    {
        GameManager.instance.dayNum++;
        GameManager.instance.UpdateDayGameState(GameManager.instance.dayStates[GameManager.instance.dayNum]);
    }

    public override void SetIsInteractable(bool value)
    {
        throw new System.NotImplementedException();
    }
}

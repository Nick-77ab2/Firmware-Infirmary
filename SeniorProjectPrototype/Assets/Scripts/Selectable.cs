using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public object element;
    public void Decide()
    {
        if(this.transform.parent.transform.parent.transform.parent.name=="TextParent"){
            NewDialogueScript.SetDecision(element);
        }
        else{
            RingCameraDialogue.SetDecision(element);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradesPlacement : Interactable
{
    [SerializeField] private UnityEvent locationSelectedEvent;
    [SerializeField] public GameObject theTool;
    bool isInteractable;
    
    void Start(){
    }

    public override void SetIsInteractable(bool value)
    { 
        isInteractable = value;
    }
    public override void Interact()
    {
        Debug.Log("Interacted with");
        if(theTool.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.name=="NewComponent")
        {
            locationSelectedEvent.Invoke();
        }
    }

    public void Placeable()
    {
        theTool.GetComponent<ScrewDriver>().setTargetParent(this.gameObject);
        this.isInteractable = false;
    }
}

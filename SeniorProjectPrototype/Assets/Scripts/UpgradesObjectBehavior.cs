using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradesObjectBehavior : Interactable
{

    [SerializeField] private UnityEvent objectGrabbedEvent;
    [SerializeField] public GameObject theTool;
    [SerializeField] public GameObject cover;
    private Vector3 originalScale;
    bool isInteractable;
    
    void Start(){
        originalScale =this.gameObject.transform.localScale;
    }

    public override void SetIsInteractable(bool value)
    { 
        isInteractable = value;
    }
    public override void Interact()
    {
        Debug.Log("Interacted with");
        if(theTool.GetComponent<ScrewDriver>().usageMode && !theTool.GetComponent<ScrewDriver>().oldComponentRemoved && this.gameObject.name=="OldComponent" && cover.GetComponent<Screws>().coverHasMoved)
        {
            objectGrabbedEvent.Invoke();
            AkSoundEngine.PostEvent("Play_Forcep", gameObject);
        }
        else if(theTool.GetComponent<ScrewDriver>().usageMode && theTool.GetComponent<ScrewDriver>().oldComponentRemoved && this.gameObject.name=="NewComponent")
        {
            objectGrabbedEvent.Invoke();
            AkSoundEngine.PostEvent("Play_Forcep", gameObject);
        }
    }

    public void SetNewParent()
    {
        theTool.GetComponent<ScrewDriver>().childOriginalScale=originalScale;
        float m_x=theTool.transform.localScale.x;
        float m_y=theTool.transform.localScale.y;
        float m_z=theTool.transform.localScale.z;
        Vector3 scalar = new Vector3(m_x/(m_y+m_z), m_y/(m_x+m_z),m_z/(m_x+m_y));
        this.gameObject.transform.SetParent(theTool.transform.GetChild(0));
        //this.gameObject.transform.localRotation=Quaternion.Euler(90,0,0);
        //this.gameObject.transform.localScale=new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);
        this.gameObject.transform.localPosition = new Vector3(0,0, 0);
        theTool.GetComponent<ScrewDriver>().hasChild=true;
    }
}

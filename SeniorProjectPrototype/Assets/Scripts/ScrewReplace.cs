using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrewReplace : Interactable
{
    public bool touchingScrew=false;
    public bool itemContained=false;
    public GameObject cover;
    public GameObject theScrew;
    [SerializeField] private UnityEvent locationSelectedEvent;
    [SerializeField] public GameObject theTool;
    bool isInteractable;
    //Write code for trigger and exclusivity for screw. Deal with only one object placeable in it (probably count int). Pull in parent object for location bool.
    // Start is called before the first frame update
    void Start()
    {
        itemContained=false;
        Debug.Log("I " + itemContained + " Children.");
    }

    /* Outdated
    void Update()
    {
        if(touchingScrew && Input.GetMouseButtonDown(1) && cover.GetComponent<Screws>().coverBackOn && itemContained==false)
        {
            AkSoundEngine.PostEvent("Play_Drill", gameObject);
            itemContained=true;
            if(!cover.GetComponent<Screws>().screws.Contains(theScrew))
            {
                cover.GetComponent<Screws>().screws.Add(theScrew);
                cover.GetComponent<Screws>().numScrewsLeft+=1;
            }
        }
    }
    */

    public override void SetIsInteractable(bool value)
    { 
        isInteractable = value;
    }
    public override void Interact()
    {
        Debug.Log("Interacted with");
        //AkSoundEngine.PostEvent("Play_Forcep", gameObject);
        if(theTool.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.name.Contains("Screw") && !itemContained && cover.GetComponent<Screws>().coverBackOn )
        {
            theScrew=theTool.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            locationSelectedEvent.Invoke();
            //AkSoundEngine.PostEvent("Play_Forcep", gameObject);
            itemContained=true;
            theScrew.GetComponent<ScrewMechanics>().touchingScrew=false;
            theScrew.GetComponent<ScrewMechanics>().canPickBackUp=false;
            if(!cover.GetComponent<Screws>().screws.Contains(theScrew))
            {
                cover.GetComponent<Screws>().screws.Add(theScrew);
                cover.GetComponent<Screws>().numScrewsLeft+=1;
            }
        }
    }

    public void Placeable()
    {
        theTool.GetComponent<ScrewDriver>().setTargetParent(this.gameObject);
        this.isInteractable = false;
    }
}

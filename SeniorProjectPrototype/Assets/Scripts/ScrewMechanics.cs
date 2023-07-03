using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewMechanics : Interactable
{
    //Get relevant GameObjects and scripts
    public GameObject movingPart;
    private Screws theScrews;
    private ScrewDriver theDriver;
    private GameObject theTool;
    //integers and other necessary variables
    private int turnCount=0;
    private bool isRemoved=false;
    private float height;
    private float height1;
    public bool touchingScrew=false;
    public float originalZ;
    bool isInteractable;

    //Vectors
    private Vector3 m_Size;
    private Vector3 this_Size;
    public Vector3 originalScale;

    //List of Bools for if statements
    private bool wasClicked=false;
    public bool canPickBackUp=true;

    void Start(){
        theScrews = movingPart.GetComponent<Screws>();
        theTool = GameObject.Find("ScrewDriverTool");
        theDriver = theTool.GetComponent<ScrewDriver>();
        originalScale = this.gameObject.transform.localScale;
        originalZ=this.gameObject.transform.localPosition.z;
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.name=="Holder" && other.transform.parent.name.Contains("ScrewDriver")){
            touchingScrew=true;
        }
    
    }
    void OnTriggerExit(Collider other)
    {
        if(other.name=="Holder" && other.transform.parent.name.Contains("ScrewDriver")){
            touchingScrew=false;
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
        if(theTool.GetComponent<ScrewDriver>().usageMode && canPickBackUp)
        {
            //AkSoundEngine.PostEvent("Play_Drill", gameObject);
            touchingScrew=true;
            if(CanPickBackUp()){
                PickUp();
            }
        }

    }
    void Update()
    {
        if(WasClicked()){
            touchingScrew=false;
            UnityEngine.Debug.Log("Primary button pressed");
            turnCount+=1;
        }

        else if(CanRemove()){
            theScrews.screws.Remove(this.gameObject);
            theScrews.numScrewsLeft-=1;
            isRemoved=true;
            PickUp();
        }

        else if(WasClicked() && theDriver.hasChild){
            UnityEngine.Debug.Log("The Screwdriver has a child and cannot get another");
        }
        //Create empty object with Colliders on Moveable part for re-placement of screws

    }

    public bool CanRemove(){
        if(turnCount==1 && !isRemoved){
            return true;
        }
        else{
            return false;
        }
    }

    public bool WasClicked(){
        if(turnCount!=1 && touchingScrew && !theDriver.hasChild && Input.GetMouseButtonDown(0)){
            return true;
        }
        else{
            return false;
        }
    }

    public bool CanPickBackUp(){
        if(turnCount==1 && touchingScrew && !theDriver.hasChild && Input.GetMouseButtonDown(0)){
            return true;
        }
        else{
            return false;
        }
    }

    public void PickUp(){
        theTool.GetComponent<ScrewDriver>().childOriginalScale=originalScale;
        //theTool.GetComponent<ScrewDriver>().isntInToolArea();
        float m_x=theTool.transform.localScale.x;
        float m_y=theTool.transform.localScale.y;
        float m_z=theTool.transform.localScale.z;
        Vector3 scalar = new Vector3(m_x/(m_y+m_z), m_y/(m_x+m_z),m_z/(m_x+m_y));
        this.gameObject.transform.SetParent(theTool.transform.GetChild(0));
        theDriver.hasChild=true;
        /*
        if(this.gameObject.transform.parent.name=="UpgradesCanvas Variant Leg"){
            this.gameObject.transform.localRotation=Quaternion.Euler(0.292f,74.343f,8.038f);
        }
        else{
            this.gameObject.transform.localRotation=Quaternion.Euler(-90,0,0);
        }
        */
        this.gameObject.transform.localRotation=Quaternion.Euler(-90,0,0);
        this.gameObject.transform.localScale=new Vector3(this.transform.localScale.x,this.transform.localScale.x,this.transform.localScale.z);
        this.gameObject.transform.localPosition = new Vector3(0,0.05f, 0);
    }
}

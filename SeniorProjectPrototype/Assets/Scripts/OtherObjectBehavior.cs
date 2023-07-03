using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherObjectBehavior : Interactable
{
    bool isInteractable;
    bool interactedWith=false;
    float waitTime;
    public GameObject varHolder;
    public GameObject healthHolder;
    public ScrewReplace screwArea1;
    public ScrewReplace screwArea2;
    public ScrewReplace screwArea3;
    public ScrewReplace screwArea4;
    public ScrewMechanics screw1;
    public ScrewMechanics screw2;
    public ScrewMechanics screw3;
    public ScrewMechanics screw4;
    public bool cannotInteract=false;
    public void Start(){
        waitTime=.1f;
    }
    public void Update(){
        if(interactedWith && waitTime<0.1f){
            waitTime+=Time.deltaTime;
        }
        if(waitTime>=0.1f){
            interactedWith=false;
        }
        /*
        if(!this.gameObject.GetComponent<Screws>().coverBackOn && (screw1.touchingScrew || screw2.touchingScrew || screw3.touchingScrew || screw4.touchingScrew)){
            Debug.LogWarning("You're touching a screw");
            cannotInteract=true;
        }
        else if(this.gameObject.GetComponent<Screws>().coverBackOn && ((screwArea1.touchingScrew && !screwArea1.itemContained) || (screwArea2.touchingScrew && !screwArea2.itemContained) || (screwArea3.touchingScrew && !screwArea3.itemContained) || (screwArea4.touchingScrew  && !screwArea4.itemContained))){
            Debug.LogWarning("You're trying to place a screw");
             cannotInteract=true;
        }
        else{
            Debug.LogWarning("you're not touching anything");
             cannotInteract=false;
        }
        */
    }
    // Start is called before the first frame update
    public override void SetIsInteractable(bool value)
    { 
        isInteractable = value;
    }
    public override void Interact()
    {
        if(waitTime>=0.1f && !cannotInteract){
            interactedWith = true;
            waitTime=0f;
            Debug.Log(this.transform.name + " has been interacted with. Minus 20 points for griffindor.");
            varHolder.GetComponent<UpgradeVarManagement>().setHealth(varHolder.GetComponent<UpgradeVarManagement>().getHealth()-20);
            healthHolder.GetComponent<Slider>().value = 1 - ((100f - varHolder.GetComponent<UpgradeVarManagement>().getHealth())/100);
        }
    }
}

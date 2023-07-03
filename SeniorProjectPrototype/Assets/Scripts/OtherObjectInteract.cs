using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherObjectInteract : Interactable
{
    bool isInteractable;
    bool interactedWith=false;
    float waitTime;
    public GameObject varHolder;
    public GameObject healthHolder;
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
    }
    // Start is called before the first frame update
    public override void SetIsInteractable(bool value)
    { 
        isInteractable = value;
    }
    public override void Interact()
    {
        ScrewDriver screwdriver = GameObject.Find("ScrewDriverTool").GetComponent<ScrewDriver>();
        ScrewDriver forceps = GameObject.Find("ForcepsTool").GetComponent<ScrewDriver>();
        if(waitTime>=0.1f && (!screwdriver.isInToolArea || !forceps.isInToolArea )){
            interactedWith = true;
            waitTime=0f;
            Debug.Log(this.transform.name + " has been interacted with. Minus 20 points for griffindor.");
            varHolder.GetComponent<UpgradeVarManagement>().setHealth(varHolder.GetComponent<UpgradeVarManagement>().getHealth()-20);
            healthHolder.GetComponent<Slider>().value = 1 - ((100f - varHolder.GetComponent<UpgradeVarManagement>().getHealth())/100);
        }
    }
}
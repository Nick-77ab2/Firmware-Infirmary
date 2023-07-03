using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVarManagement : MonoBehaviour
{
    [SerializeField] public bool oldComponentRemoved=false;
    [SerializeField] public bool newObjectInPlace =false;
    [SerializeField] public int health=100;
    [SerializeField] public bool allScrewsInPlace=false;
    private NewDialogueScript script;
    private bool hasResult=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update(){
        /*
        if(hasResult){
            this.GetComponent<UnityEngine.EventSystems.PhysicsRaycaster>().enabled=false;
            this.GetComponentInChildren<ScrewDriver>().enabled=false;
        }
        */
        if (oldComponentRemoved && newObjectInPlace && allScrewsInPlace && !hasResult) {
            Debug.Log("Upgrades game is returning success.");
            script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
            script.isSuccess = true;
            hasResult = true;
        }
        else if (health > 0 && health <= 40 && !hasResult && oldComponentRemoved && newObjectInPlace && allScrewsInPlace) {
            Debug.Log("Upgrades game is returning fail.");
            script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
            script.isFail = true;
            Debug.Log("failure status" + script.isFail);
            hasResult = true;
        }
        else if (health <= 0) 
        {
            GameManager.instance.FailDay();
        }
    }

    public void setOldComponentRemoved(bool val){
        oldComponentRemoved=val;
    }

    public void setNewObjectInPlace(bool val){
        newObjectInPlace=val;
    }

    public bool getOldComponentRemoved(){
        return oldComponentRemoved;
    }

    public bool getNewObjectInPlace(){
        return newObjectInPlace;
    }

    public int getHealth(){
        return health;
    }

    public void setHealth(int val){
        health=val;
    }

     public bool getAllScrewsInPlace(){
        return allScrewsInPlace;
    }

    public void setAllScrewsInPlace(bool val){
        allScrewsInPlace=val;
    }
}

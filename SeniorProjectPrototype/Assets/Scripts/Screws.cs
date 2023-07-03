using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screws : MonoBehaviour
{
    public List<GameObject> screws= new List<GameObject>();
    public int numScrews;
    public int numScrewsLeft;
    private Drag3D drag;
    public bool coverBackOn=false;
    Vector3 coverOriginalLocation;
    public bool coverHasMoved=false;
    public bool allScrewsInPlace=false;
    private UpgradeVarManagement varManager;
    private OtherObjectBehavior otherBehavior;

    
    // Start is called before the first frame update
    void Start()
    {
        otherBehavior=this.gameObject.GetComponent<OtherObjectBehavior>();
        coverOriginalLocation = this.gameObject.transform.position;
        drag=this.gameObject.GetComponent<Drag3D>();
        numScrews = screws.Count;
        numScrewsLeft=numScrews;
        varManager=this.transform.parent.gameObject.GetComponent<UpgradeVarManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(numScrewsLeft==numScrews && !coverBackOn){
            drag.isEnabled=false;

        }
        else if(numScrewsLeft==numScrews && coverBackOn){
            otherBehavior.screw1.GetComponent<ScrewMechanics>().enabled=false;
            otherBehavior.screw2.GetComponent<ScrewMechanics>().enabled=false;
            otherBehavior.screw3.GetComponent<ScrewMechanics>().enabled=false;
            otherBehavior.screw4.GetComponent<ScrewMechanics>().enabled=false;
            allScrewsInPlace=true;
            varManager.setAllScrewsInPlace(allScrewsInPlace);
        }
        else if(numScrewsLeft!=numScrews && varManager.getAllScrewsInPlace()!=false) {
            allScrewsInPlace=false;
            varManager.setAllScrewsInPlace(allScrewsInPlace);
        }
        if(numScrewsLeft==0){
            drag.isEnabled=true;
        }
        if(Vector3.Distance(this.gameObject.transform.position,coverOriginalLocation)>=0.1 && !coverHasMoved){
            coverHasMoved=true;
        }
        if(Vector3.Distance(this.gameObject.transform.position,coverOriginalLocation)<=0.6 && coverHasMoved){
            Debug.Log("One has run");
            coverBackOn=true;
            this.gameObject.transform.position=coverOriginalLocation;
        }
        else if(Vector3.Distance(this.gameObject.transform.position,coverOriginalLocation)>=0.6 && coverHasMoved){
            coverBackOn=false;
            Debug.Log("Two has run");
        }
        //Debug.Log(Vector3.Distance(this.gameObject.transform.position,coverOriginalLocation));
    }

    
}

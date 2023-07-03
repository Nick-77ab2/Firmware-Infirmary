using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Note: This ScrewDriver script is actually the base tool script.
public class ScrewDriver : MonoBehaviour
{
    private float mZCoord;
    public bool usageMode = false;
    public float usageX;
    public float usageY;
    public float usageZ;
    public bool isInToolArea=false;
    public bool canPlace=false;
    private bool coverBackOn=false;
    public bool canGrabOldObject=false;
    public bool oldComponentRemoved=false;
    public bool newObjectInPlace=false;
    private GameObject targetParent;
    //use the below to seamlessly convert from world to local to not have issues with scene location changes etc.
    private float worldToLocalX;
    private float worldToLocalY;
    private float worldToLocalZ;
    private GameObject currentChild;
    public Vector3 childOriginalScale;
    public Vector3 startRotation;
    public GameObject cover;
    private Camera cam;
    public bool hasChild=false;
    public Vector3 originalPosition;
    public Quaternion originalRotation;
    private ESCListen escListen;

    void Start(){
        originalPosition= this.transform.position;
        originalRotation=  this.transform.rotation;
        escListen = GameObject.Find("MiscManager").GetComponent<ESCListen>();
        cam = this.transform.parent.transform.parent.GetComponent<Canvas>().worldCamera;
        Debug.Log(this.transform.name);
        startRotation= new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        //setWorldToLocal();
    }
    //Update occurs every game frame
    void Update(){
        //Move tool to mouse
        if(usageMode && !escListen.escActive){
            //this.transform.localPosition =new Vector3(GetMouseWorldPos().x*worldToLocalX, GetMouseWorldPos().y*worldToLocalY, this.transform.localPosition.z);
            //Check for Holder having children
            if(this.transform.GetChild(0).childCount>0){
                hasChild=true;
            }
            Debug.LogWarning(cam.transform.name + cam.transform.position);
            this.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.localPosition.z-.5f));
            RunTimeActions();
        }
        if(escListen.escActive && hasChild && usageMode){
            currentChild=this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
            if(currentChild.name=="OldComponent"){
                    this.transform.parent.GetComponent<UpgradeVarManagement>().setOldComponentRemoved(true);
                }
            this.gameObject.transform.position = this.originalPosition;
            currentChild.transform.parent= this.transform.parent;
            if(currentChild.name.Contains("Screw")){
                currentChild.GetComponent<ScrewMechanics>().touchingScrew=false;
                PlaceChild(currentChild.transform.localPosition.x+Random.Range(-240f,-90f), currentChild.transform.localPosition.y+Random.Range(-124f,59f), 50);
            }
            else{
                PlaceChild(currentChild.transform.localPosition.x+Random.Range(-300f,-200f), currentChild.transform.localPosition.y+Random.Range(-124f,59f), 20);
            }
            usageMode=false;
            hasChild=false;
            this.gameObject.transform.rotation = this.originalRotation;
        }
        if(escListen.escActive && usageMode){
            this.gameObject.transform.position = this.originalPosition;
            this.gameObject.transform.rotation = this.originalRotation;
            usageMode=false;
        }
        //constantly keep vars up to date
        if(oldComponentRemoved!=this.transform.parent.GetComponent<UpgradeVarManagement>().getOldComponentRemoved()){
            oldComponentRemoved=this.transform.parent.GetComponent<UpgradeVarManagement>().getOldComponentRemoved();
        }
        if(newObjectInPlace!=this.transform.parent.GetComponent<UpgradeVarManagement>().getNewObjectInPlace()){
            newObjectInPlace=this.transform.parent.GetComponent<UpgradeVarManagement>().getNewObjectInPlace();
        }
    }
    // Must run this separately due to double use of right click via linerender and mouseOver (fml)
    //Notified/runs when the mouse hovers over the scripts parent object
    void OnMouseOver(){
        if(!escListen.escActive){
            //On clicking the Tool, move it to position/follow the mouse and hide the mouse.
            if (!usageMode && Input.GetMouseButton(0)){
                AkSoundEngine.PostEvent("Play_HoverSelection", this.gameObject);
                usageMode=true;
                Cursor.visible=false;
                this.transform.rotation=Quaternion.Euler(startRotation.x + usageX,startRotation.y + usageY,startRotation.z+ usageZ);
                this.transform.localPosition=new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z); //make public field
            }
            //If it doesn't have a child and you rightclick toolbar, place the tool back down.
            if(Input.GetMouseButtonDown(1) && isInToolArea && usageMode && !hasChild){
                usageMode=false;
                Cursor.visible=true;
                this.transform.rotation=Quaternion.Euler(startRotation.x,startRotation.y,startRotation.z);
                this.transform.localPosition=new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z);
            }
        }
    }
    public void RunTimeActions(){
        if(!escListen.escActive){
            //If it does have a child and you right click in the toolbar, place the child down
            if(Input.GetMouseButtonDown(1) && isInToolArea && usageMode && hasChild)
            {
                AkSoundEngine.PostEvent("Play_Forcep", this.gameObject);
                currentChild=this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                if(currentChild.name=="OldComponent"){
                    this.transform.parent.GetComponent<UpgradeVarManagement>().setOldComponentRemoved(true);
                }
                currentChild.transform.parent= this.transform.parent;
                if(currentChild.name.Contains("Screw")){
                    AkSoundEngine.PostEvent("Play_Drill", this.gameObject);
                    currentChild.GetComponent<ScrewMechanics>().touchingScrew=false;
                    PlaceChild(currentChild.transform.localPosition.x, currentChild.transform.localPosition.y, 50);
                }
                else{
                    PlaceChild(currentChild.transform.localPosition.x, currentChild.transform.localPosition.y, 20);
                }
            }
            else if(targetParent!=null){
                if(hasChild){
                    AkSoundEngine.PostEvent("Play_Drill", gameObject);
                    currentChild=this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    if(currentChild.name=="NewComponent"){
                        PlaceNewObjectDown();
                        targetParent=null;
                        this.transform.parent.GetComponent<UpgradeVarManagement>().setNewObjectInPlace(true);
                    }
                    else{
                        PlaceNewObjectDown();
                        targetParent=null;
                    }
                }
                else{
                    Debug.Log("There's a target parent but no child");
                }
            }
            //If it has a child and you can place the child in the location you right clicked, then place the child.
            //Debug.Log("usageMode: " + usageMode + "\nNewObjectInPlace: " + newObjectInPlace + "\nhasChild: " + hasChild + "\nCanPlace: " + canPlace + "\nCoverSetting: " + getCoverSetting());
            else if(Input.GetMouseButtonDown(1) && canPlace && usageMode && hasChild && newObjectInPlace && getCoverSetting())
            {
                AkSoundEngine.PostEvent("Play_Drill", gameObject);
                Debug.Log("This is the culprit!");
                currentChild=this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                currentChild.transform.parent= this.transform.parent;
                PlaceChild(currentChild.transform.localPosition.x, currentChild.transform.localPosition.y, currentChild.transform.GetComponent<ScrewMechanics>().originalZ);
            }
            /*
            else if(canPlace && newObjectInPlace && usageMode && hasChild){
                Debug.Log("There's issues with getCoverSettings");
            }
            else if(canPlace && usageMode && hasChild && newObjectInPlace && getCoverSetting()){
                Debug.Log("Yea everything's true, it just doesn't like you Nick");
            }
            */
        }
    }
    //I only use this for editor-based issues and reasons
    void OnMouseExit()
    {
        Debug.Log("Exiting!!!");
        //constantly make sure tool is on the mouse
        if(usageMode){
            //this.transform.localPosition =new Vector3(GetMouseWorldPos().x*worldToLocalX, GetMouseWorldPos().y*worldToLocalY, -cam.transform.position.z);
            this.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z-6));
        }
    }

    public void PlaceNewObjectDown(){
        currentChild=this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        currentChild.transform.parent= targetParent.transform;
        currentChild.transform.localPosition=new Vector3(currentChild.transform.localPosition.x, currentChild.transform.localPosition.y, 0);
        //PlaceChild(currentChild.transform.localPosition.x, currentChild.transform.localPosition.y, 0);
        hasChild=false;
        if(canPlace==true){
            canPlace=false;
        }
    }

    public void PlaceChild(float _x, float _y, float _z){
        if(currentChild.tag!="Middle"){
            currentChild.transform.localRotation=Quaternion.Euler(0,0,0);
            Debug.Log("Name: " + currentChild.name);
            currentChild.transform.localPosition=new Vector3(_x, _y, _z);
            currentChild.transform.localScale= new Vector3(childOriginalScale.x,childOriginalScale.y,childOriginalScale.z);
        }
        else{
            currentChild.transform.localPosition=new Vector3(_x, _y, _z);
            Debug.Log("Name: " + currentChild.name);
            currentChild.transform.localRotation=Quaternion.Euler(0, -90, -90);
        }
        hasChild=false;
        if(canPlace==true){
            canPlace=false;
        }
    }

    private Vector3 GetMouseWorldPos(){
        // pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;
        //Camera cam = this.transform.parent.transform.parent.GetComponent<Camera>();
        //z coordinate of game object on screen
        mousePoint.z = mZCoord;

        return this.transform.parent.transform.parent.GetComponent<Canvas>().worldCamera.ScreenToWorldPoint(mousePoint);
    }

    public void inToolArea(){
        isInToolArea=true;
    }

    public void isntInToolArea(){
        isInToolArea=false;
    }

    public void setWorldToLocal(){
        Camera cam = this.transform.parent.transform.parent.GetComponent<Canvas>().worldCamera;
        Vector3 screenPos = cam.WorldToScreenPoint(this.transform.position);
        worldToLocalX=this.transform.localPosition.x/this.transform.position.x;
        worldToLocalY=this.transform.localPosition.y/this.transform.position.y;
        worldToLocalZ=this.transform.localPosition.z/this.transform.position.z;
    }

    public bool getCoverSetting(){
        return cover.GetComponent<Screws>().coverBackOn;
    }

    public void setTargetParent(GameObject theParent){
        targetParent=theParent;
    }


}

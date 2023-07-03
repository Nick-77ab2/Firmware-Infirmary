using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag3D : MonoBehaviour
{
    private Vector3 mOffset;
    public Vector3 finalOffset;
    public Vector3 startingPoint;
    private float mZCoord;
    public bool isEnabled=false;
    private float diffX;
    private float diffY;
    private Camera cam;
    public Vector3 globalCurrentPos;
    private ESCListen escListen;
    
    void Start(){
        escListen = GameObject.Find("MiscManager").GetComponent<ESCListen>();
        startingPoint=gameObject.transform.position;
        cam = this.transform.parent.transform.parent.GetComponent<Canvas>().worldCamera;
        mZCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
    }
    void Update(){
        if(isEnabled){
            globalCurrentPos=gameObject.transform.position;
            if(Mathf.Abs(globalCurrentPos.z-startingPoint.z)>2){
                transform.position = new Vector3(transform.position.x, transform.position.y, startingPoint.z);
            }
        }
    }
    void OnMouseDown(){
        if(isEnabled && !escListen.escActive){
            // Store offset = gameobject world pos - mouse world pos
            Vector3 newPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z-1);
            mOffset = newPos - GetMouseWorldPos();
            Debug.Log("Clicked on Object");
        }
    }

    private Vector3 GetMouseWorldPos(){
        // pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        //z coordinate of game object on screen
        mousePoint.z = mZCoord;

        return cam.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag(){
        if(isEnabled && !escListen.escActive){
            Vector3 currentPosition=gameObject.transform.position;
            //Only allow the object to be moved within a range
            //if(Mathf.Abs(mOffset.x)<Mathf.Abs(finalOffset.x) && Mathf.Abs(mOffset.y)<Mathf.Abs(finalOffset.y)){
            if(Mathf.Abs(currentPosition.z-startingPoint.z)>20){
                transform.position = new Vector3(startingPoint.x, startingPoint.y, startingPoint.z);
            }
            if(Mathf.Abs(startingPoint.x-currentPosition.x)<finalOffset.x && Mathf.Abs(startingPoint.y-currentPosition.y)<finalOffset.y){
                transform.position = GetMouseWorldPos() + mOffset;
            }
        }
    }

    void OnMouseUp(){
        if(isEnabled && !escListen.escActive){
            Debug.Log("Got Here");
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z+7);
            Vector3 currentPosition=gameObject.transform.position;
            Debug.Log(currentPosition);
            if(Mathf.Abs(startingPoint.x-currentPosition.x)>finalOffset.x){
                //get x pos or neg
                float xPosNeg=currentPosition.x/Mathf.Abs(currentPosition.x);
                transform.position=new Vector3(startingPoint.x+((finalOffset.x-1)*xPosNeg),transform.position.y, transform.position.z);
                Debug.Log("x position is too great");
            }
            if(Mathf.Abs(startingPoint.y-currentPosition.y)>finalOffset.y){
                //get y pos or neg
                float yPosNeg=currentPosition.y/Mathf.Abs(currentPosition.y);
                transform.position=new Vector3(transform.position.x,startingPoint.y+((finalOffset.y-1)*yPosNeg), transform.position.z);
            }
        }
        /*----------------Code for placing back on--------------------------------
        diffX=(this.transform.position.x-startingPoint.x);
        diffY=(this.transfomr.position.y-startingPoint.y);
        if(isEnabled && newObjectInPlace && (Mathf.Abs(diffX)<10) && (Mathf.Abs(diffY)<10)){
            this.transform.x=startingPoint.x;
            this.transform.y=startingPoint.y;
        }
        */
    }
}
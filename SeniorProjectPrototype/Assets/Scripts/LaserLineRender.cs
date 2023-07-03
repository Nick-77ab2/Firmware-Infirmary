using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLineRender : MonoBehaviour
{
    //Script courtesy of @Moaid_T4 from answers.unity.com
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 200f;
    private Interactable interactiveObj;
    public bool screwHit = false;
 
     void Start() {
         Vector3[] initLaserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
         laserLineRenderer.SetPositions( initLaserPositions );
         laserLineRenderer.SetWidth( laserWidth, laserWidth );
     }
 
     void Update() 
     {
        if(this.gameObject.transform.parent.gameObject.transform.GetComponent<ScrewDriver>().usageMode==true && Input.GetKeyDown(KeyCode.F) && laserLineRenderer.enabled == false ) {
            Debug.Log("F was pressed");
            laserLineRenderer.enabled=true;

        }
        else if(Input.GetKeyDown(KeyCode.F) && laserLineRenderer.enabled == true) {
            laserLineRenderer.enabled = false;
        }
        ShootLaserFromTargetPosition( transform.position, transform.TransformDirection(Vector3.up), laserMaxLength );
     }
 
     void ShootLaserFromTargetPosition( Vector3 targetPosition, Vector3 direction, float length )
     {
        Ray ray = new Ray( targetPosition, direction );
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + ( length * direction );
 
        if( Physics.Raycast( ray, out raycastHit, length ) ) {
            endPosition = raycastHit.point;
            var raycastObj = raycastHit.collider.gameObject.GetComponent<Interactable>();
            if (raycastObj != null)
            {
                interactiveObj = raycastObj;
            }
            else
            {
                ClearInteraction();
            }
        }
        else
        {
            ClearInteraction();
        }

        if (interactiveObj != null)
        {
            if (interactiveObj.gameObject.name.Contains("Screw") && screwHit == false)
            {
                AkSoundEngine.PostEvent("Play_Event", this.gameObject);
                screwHit = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("Interacting with Interactable");
                interactiveObj.Interact();
            }
        }
 
         laserLineRenderer.SetPosition( 0, targetPosition );
         laserLineRenderer.SetPosition( 1, endPosition );
     }
    
    private void ClearInteraction()
    {
        if (interactiveObj != null)
        {
            interactiveObj = null;
            screwHit = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private int rayLen = 5;
    private Interactable interactiveObj;
    private Shader shader;
    private Shader oldShader;
    private Shader oldShader1;
    private Shader oldShader2;
    private Vector3 objScale;
    private Vector3 newObjScale;
    private int runs=0;
    private int once=0;
    // Start is called before the first frame update
    void Awake()
    {
        shader=Shader.Find("Shader Graphs/Mouse_Over_Shader");
        oldShader1=Shader.Find("Shader Graphs/MainShader");
        oldShader2=Shader.Find("HDRP/Lit");
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLen))
        {
            var raycastObj = hit.collider.gameObject.GetComponent<Interactable>();
            if (raycastObj != null)
            {
                interactiveObj = raycastObj;
                if(once==0){
                    objScale = interactiveObj.gameObject.transform.localScale;
                    newObjScale = new Vector3(objScale.x*1.1f, objScale.y*1.1f, objScale.z*1.1f);
                    try{
                        ChangeChildrenMaterialShaders();
                    }
                    catch{
                        Debug.LogWarning("Either children don't exist or the children don't have materials.");
                    }
                    once=1;
                }

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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                interactiveObj.Interact();
            }
        }
    }

    private void ClearInteraction()
    {
        if (interactiveObj != null)
        {
            if(once==1){
                try{
                    ResetChildrenMaterialShaders();
                }
                catch{
                    Debug.LogWarning("Either children don't exist or the children don't have materials.");
                }
                interactiveObj = null;
            }
            once=0;
        }
    }
    void ChangeChildrenMaterialShaders()
    {
        if(runs==0){
            interactiveObj.gameObject.transform.localScale = newObjScale;
            Renderer[] children;
            children = interactiveObj.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                if(rend.gameObject.name=="Tube_Buttons"){
                    rend.material.SetColor("_Emission_Color", Color.yellow*4);
                }
                foreach(Material mat in rend.materials){
                    mat.SetFloat("_Is_Highlighted", 1);
                    mat.SetFloat("_Expansion_Amt", 0);
                }
            }
            runs+=1;
        }
    }
    void ResetChildrenMaterialShaders()
    {
        if(runs==1){
            Debug.LogWarning(oldShader);
            interactiveObj.gameObject.transform.localScale = objScale;
            Renderer[] children;
            children = interactiveObj.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in children)
            {
                if(rend.gameObject.name=="Tube_Buttons"){
                    rend.material.SetColor("_Emission_Color", Color.white/4);
                }
                foreach(Material mat in rend.materials){
                     mat.SetFloat("_Is_Highlighted", 0);
                }
            }
            runs-=1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSignShaderEditInGame : MonoBehaviour
{
    // Material of object a.k.a. Open sign material
    public Material emissionMat;
    // setable Emission level editable in scene in the shader within the material
    public float emissionLevel;
    // max value of the emission level
    public float maxEmission;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
        emissionLevel = 0;
        //using the property name of the emission level dictated by the shader graph, sets the value to 0 on start
        emissionMat.SetFloat("_Emission_Strength", emissionLevel);
    }

    // Update is called once per frame
    void Update()
    {

        // once space is pressed emisson level is set to desired level in script (i am sure you understand all of this I just want to be thorough with the comments)
         if (Input.GetKeyDown(KeyCode.Space))
         {
             if(emissionLevel <= 50000) {
                 emissionLevel = 50000;
                 emissionMat.SetFloat("_Emission_Strength", emissionLevel);
             }

         }

    }
}

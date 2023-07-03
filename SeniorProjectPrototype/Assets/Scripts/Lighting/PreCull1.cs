using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PreCull1 : MonoBehaviour
{
    public Light sun;
    
    void Start()
    {
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
    {
        if (sun != null)
            sun.enabled = true;
        // Put the code that you want to execute before the camera renders here
        // If you are using URP or HDRP, Unity calls this method automatically
        // If you are writing a custom SRP, you must call RenderPipeline.BeginCameraRendering
    }

    void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
    }
}

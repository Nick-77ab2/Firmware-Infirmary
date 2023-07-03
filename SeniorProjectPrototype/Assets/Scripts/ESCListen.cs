using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ESCListen : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public bool isLocked;
    private bool atSPaint=false;
    DrawLine draw;
    ScrewDriver theDriver;
    GameObject theTool;
    GameObject theForceps;
    public bool escActive=false;
    [SerializeField] private UnityEvent EscapePressed;
    private Camera camera;
    private GameObject currentChild;

    // Update is called once per frame
    void Update()
    {
        camera = Camera.main;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        
            if (GameIsPaused)
            {
            Resume();
            }
            else
            {
            Pause();
            }
        }
    }

    public void Resume()
    {
        EscapePressed.Invoke();
        escActive=false;
        if(atSPaint==true){
            draw.SetTheCursor();
            atSPaint=false;
        }
        pauseMenuUI.SetActive(false);
        Debug.Log("Set to inactive");
        Time.timeScale = 1f;
        GameIsPaused = false;
        if(isLocked){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else{
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
         try{
            camera.gameObject.GetComponent<Raycast>().enabled=true;
        }
        catch{
        }
    }
    public void Pause()
    {
        Debug.Log(camera);
        escActive=true;
        try{
            draw = GameObject.Find("PaintController").GetComponent<DrawLine>();
            if(draw.enabled==true){
                atSPaint=true;
                draw.ResetCursor();   
            }
            else{
                atSPaint=false;
            }
        }
        catch{
            Debug.LogWarning("We're not painting homie.");
        }
        try{
            camera.gameObject.GetComponent<Raycast>().enabled=false;
        }
        catch{
        }
        if(Cursor.lockState == CursorLockMode.Locked){
            isLocked = true;
        }
        else{
            isLocked=false;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}

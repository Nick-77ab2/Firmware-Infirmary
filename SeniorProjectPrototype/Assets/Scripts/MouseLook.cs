using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TestingChanges
public class MouseLook : MonoBehaviour
{
    [SerializeField] public float xRotation;
    [SerializeField] public float yRotation;
    [SerializeField]
    private AK.Wwise.RTPC BGMVol;
    [SerializeField]
    private AK.Wwise.RTPC SFXVol;
    public Transform orientation;
    public Vector2 turn;
    public Vector3 deltaMove;
    [HideInInspector]public float sensitivity;
    PlayerMovement3D playerMovement;
    private float x=0f;

    void Start()
    {
        Debug.LogWarning("BGM Vol:" + PlayerPrefs.GetFloat("BGMVolume"));
        Debug.LogWarning("SFX Vol:" + PlayerPrefs.GetFloat("SFXVolume"));
        BGMVol.SetGlobalValue(PlayerPrefs.GetFloat("BGMVolume"));
        SFXVol.SetGlobalValue(PlayerPrefs.GetFloat("SFXVolume"));
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible=false;
        if(!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            PlayerPrefs.SetFloat("MouseSensitivity", this.sensitivity);
        }
        ChangeSensitivity(PlayerPrefs.GetFloat("MouseSensitivity"));
        playerMovement = orientation.transform.GetComponentInParent<PlayerMovement3D>();
    }

    void Update()
    {
        //QOL fixes
        if(x<.5f)
            x+=Time.deltaTime;

        // if(Cursor.visible!=false)
        //     Cursor.visible=false;

        // if(Cursor.lockState!= CursorLockMode.Locked)
        //     Cursor.lockState = CursorLockMode.Locked;

        //actual important code
        if(playerMovement.enabled && x>0.4f)
        {
        turn.x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        turn.y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        yRotation += turn.x;
        xRotation -= turn.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        orientation.parent.rotation = Quaternion.Euler(0, yRotation, 0);
        }

    }
    public void ChangeSensitivity(float newSensitivity){
        this.sensitivity = newSensitivity;
    }
}

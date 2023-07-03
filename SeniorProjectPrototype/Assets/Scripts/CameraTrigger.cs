using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
//Testing with Streams Tom Card

public class CameraTrigger : Interactable
{
    [SerializeField] private Camera twoDimCamera;
    [SerializeField] private Camera threeDimCamera;
    [SerializeField] private GameObject firstPersonUi;
    [SerializeField] private GameObject Ui2D;
    [SerializeField] private GameObject gameController;
    [SerializeField] private Camera twoDimCamera2;
    [SerializeField] private GameObject Ui2D2;
    [SerializeField] private GameObject gameController2;
    [SerializeField] private PlayerMovement3D pm;
    [SerializeField] private MouseLook mouseLook;

    [SerializeField] private UnityEvent changeToCamEvent;

    bool isInteractable = true;
    private bool isChangeable = true;
    public float FullScreenOrthographicSize;

    public override void Interact()
    {
        if (!twoDimCamera.isActiveAndEnabled && isChangeable && isInteractable)
        {
            changeToCamEvent.Invoke();
        }
    }

    public override void SetIsInteractable(bool value)
    {
        isInteractable = value;
    }

    public void open2DCam()
    {
        Debug.Log(twoDimCamera.name);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible=true;
        threeDimCamera.enabled = false;
        threeDimCamera.gameObject.SetActive(false);
        twoDimCamera.gameObject.SetActive(true);
        gameController.SetActive(true);
        Ui2D.SetActive(true);
        twoDimCamera.enabled = true;
        pm.disableMovement();
        firstPersonUi.SetActive(false);
        mouseLook.enabled = false;
    }

    public void close2DCam()
    {
        Debug.Log("exiting");
        firstPersonUi.SetActive(true);
        twoDimCamera.enabled = false;
        Ui2D.SetActive(false);
        twoDimCamera.gameObject.SetActive(false);
        gameController.SetActive(false);
        threeDimCamera.gameObject.SetActive(true);
        threeDimCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible=false;
        pm.enableMovement();
        mouseLook.enabled = true;
    }

    public void close2DCamGame()
    {
        Debug.Log("exiting");
        firstPersonUi.SetActive(true);
        twoDimCamera.enabled = false;
        twoDimCamera2.enabled = false;
        Ui2D.SetActive(false);
        Ui2D2.SetActive(false);
        twoDimCamera.gameObject.SetActive(false);
        twoDimCamera2.gameObject.SetActive(false);
        gameController.SetActive(false);
        gameController2.SetActive(false);
        threeDimCamera.gameObject.SetActive(true);
        threeDimCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pm.enableMovement();
        mouseLook.enabled = true;
    }

    public void disableChangable()
    {
        isChangeable = false;
    }

    public void enableChangable()
    {
        isChangeable = true;
    }

    public void changeGame1(Camera gameCamera1, GameObject gameUI1, GameObject gameController1)
    {
        twoDimCamera = gameCamera1;
        Ui2D = gameUI1;
        gameController = gameController1;
    }

    public void changeGame2(Camera gameCamera1, GameObject gameUI1, GameObject gameController1)
    {
        twoDimCamera2 = gameCamera1;
        Ui2D2 = gameUI1;
        gameController2 = gameController1;
    }
}

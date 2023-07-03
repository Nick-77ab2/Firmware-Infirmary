using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraController : MonoBehaviour {

    public Camera game1Camera;
    public Camera game2Camera;
    public GameObject game1Ui;
    public GameObject game2Ui;
    public GameObject game1Controller;
    public GameObject game2Controller;
    public float FullScreenOrthographicSize;

    public void changeToGame2() {
        game2Camera.rect = new Rect(0f, 0f, 1f, 1f);
        game2Camera.orthographicSize = FullScreenOrthographicSize * game2Camera.rect.height;
        game1Camera.enabled = false;
        game1Ui.SetActive(false);
        game1Camera.gameObject.SetActive(false);
        game1Controller.SetActive(false);

        game2Controller.SetActive(true);
        game2Camera.gameObject.SetActive(true);
        game2Ui.SetActive(true);
        game2Camera.enabled = true;
    }

    public void changeToMenu()
    {
        game2Camera.enabled = false;
        game2Camera.gameObject.SetActive(false);
        game2Ui.SetActive(false);
        game2Controller.SetActive(false);

        game1Camera.gameObject.SetActive(true);
        game1Ui.SetActive(true);
        game1Camera.enabled = true;
    }

    public void changeGame1(Camera gameCamera1, GameObject gameUI1, GameObject gameController1)
    {
        game1Camera = gameCamera1;
        game1Ui = gameUI1;
        game1Controller = gameController1;
    }

    public void changeGame2(Camera gameCamera1, GameObject gameUI1, GameObject gameController1)
    {
        game2Camera = gameCamera1;
        game2Ui = gameUI1;
        game2Controller = gameController1;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public CameraTrigger camTrigger;
    public MenuCameraController menuCamContr;
    public DialogueManager dialogueManager;

    public Camera gameCamera1;
    public GameObject gameUi1;
    public GameObject gameController1;
    public GameObject exit1;
    public Canvas canvas1;
    public Camera gameCamera1v2;
    public GameObject gameUi1v2;
    public GameObject gameController1v2;
    public GameObject exit1v2;
    public Canvas canvas1v2;

    public Camera gameCamera2;
    public GameObject gameUi2;
    public GameObject gameController2;
    public GameObject exit2;
    public Canvas canvas2;
    public Camera gameCamera2v2;
    public GameObject gameUi2v2;
    public GameObject gameController2v2;
    public GameObject exit2v2;
    public Canvas canvas2v2;

    public Camera gameCamera3;
    public GameObject gameUi3;
    public GameObject gameController3;
    public GameObject exit3;
    public Canvas canvas3;
    public Camera gameCamera3v2;
    public GameObject gameUi3v2;
    public GameObject gameController3v2;
    public GameObject exit3v2;
    public Canvas canvas3v2;

    public Camera gameCamera4;
    public GameObject gameUi4;
    public GameObject gameController4;
    public GameObject exit4;
    public Canvas canvas4;
    public Camera gameCamera4v2;
    public GameObject gameUi4v2;
    public GameObject gameController4v2;
    public GameObject exit4v2;
    public Canvas canvas4v2;

    public Camera gameCamera5;
    public GameObject gameUi5;
    public GameObject gameController5;
    public GameObject exit5;
    public Canvas canvas5;
    public Camera gameCamera5v2;
    public GameObject gameUi5v2;
    public GameObject gameController5v2;
    public GameObject exit5v2;
    public Canvas canvas5v2;

    public Camera gameCamera6;
    public GameObject gameUi6;
    public GameObject gameController6;
    public GameObject exit6;
    public Canvas canvas6;
    public Camera gameCamera6v2;
    public GameObject gameUi6v2;
    public GameObject gameController6v2;
    public GameObject exit6v2;
    public Canvas canvas6v2;

    public Camera gameCamera71;
    public GameObject gameUi71;
    public GameObject gameController71;
    public GameObject exit71;
    public Canvas canvas71;
    public Camera gameCamera71v2;
    public GameObject gameUi71v2;
    public GameObject gameController71v2;
    public GameObject exit71v2;
    public Canvas canvas71v2;

    public Camera gameCamera72;
    public GameObject gameUi72;
    public GameObject gameController72;
    public GameObject exit72;
    public Canvas canvas72;
    public Camera gameCamera72v2;
    public GameObject gameUi72v2;
    public GameObject gameController72v2;
    public GameObject exit72v2;
    public Canvas canvas72v2;

    public Camera gameCamera8;
    public GameObject gameUi8;
    public GameObject gameController8;
    public GameObject exit8;
    public Canvas canvas8;
    public Camera gameCamera8v2;
    public GameObject gameUi8v2;
    public GameObject gameController8v2;
    public GameObject exit8v2;
    public Canvas canvas8v2;

    public Camera gameCamera9;
    public GameObject gameUi9;
    public GameObject gameController9;
    public GameObject exit9;
    public Canvas canvas9;
    public Camera gameCamera9v2;
    public GameObject gameUi9v2;
    public GameObject gameController9v2;
    public GameObject exit9v2;
    public Canvas canvas9v2;

    public Camera gameCamera10;
    public GameObject gameUi10;
    public GameObject gameController10;
    public GameObject exit10;
    public Canvas canvas10;
    public Camera gameCamera10v2;
    public GameObject gameUi10v2;
    public GameObject gameController10v2;
    public GameObject exit10v2;
    public Canvas canvas10v2;

    public Camera gameCamera11;
    public GameObject gameUi11;
    public GameObject gameController11;
    public GameObject exit11;
    public Canvas canvas11;
    public Camera gameCamera11v2;
    public GameObject gameUi11v2;
    public GameObject gameController11v2;
    public GameObject exit11v2;
    public Canvas canvas11v2;

    public Camera gameCamera12;
    public GameObject gameUi12;
    public GameObject gameController12;
    public GameObject exit12;
    public Canvas canvas12;
    public Camera gameCamera12v2;
    public GameObject gameUi12v2;
    public GameObject gameController12v2;
    public GameObject exit12v2;
    public Canvas canvas12v2;

    public Dictionary<int, List<GameObject>> gameObjStorage = new Dictionary<int, List<GameObject>>();
    public Dictionary<int, List<Camera>>  cameras = new Dictionary<int, List<Camera>>();
    public Dictionary<int, List<Canvas>> canvases = new Dictionary<int, List<Canvas>>();
    void Awake()
    {
        List<GameObject> gameObjs1 = new List<GameObject>();
        gameObjs1.Add(gameUi1);
        gameObjs1.Add(gameController1);
        gameObjs1.Add(exit1);
        gameObjs1.Add(gameUi1v2);
        gameObjs1.Add(gameController1v2);
        gameObjs1.Add(exit1v2);
        gameObjStorage.Add(1, gameObjs1);
        List<Camera> camObjs1 = new List<Camera>();
        camObjs1.Add(gameCamera1);
        camObjs1.Add(gameCamera1v2);
        cameras.Add(1, camObjs1);
        List<Canvas> canObjs1 = new List<Canvas>();
        canObjs1.Add(canvas1);
        canObjs1.Add(canvas1v2);
        canvases.Add(1, canObjs1);

        List<GameObject> gameObjs2 = new List<GameObject>();
        gameObjs2.Add(gameUi2);
        gameObjs2.Add(gameController2);
        gameObjs2.Add(exit2);
        gameObjs2.Add(gameUi2v2);
        gameObjs2.Add(gameController2v2);
        gameObjs2.Add(exit2v2);
        gameObjStorage.Add(2, gameObjs2);
        List<Camera> camObjs2 = new List<Camera>();
        camObjs2.Add(gameCamera2);
        camObjs2.Add(gameCamera2v2);
        cameras.Add(2, camObjs2);
        List<Canvas> canObjs2 = new List<Canvas>();
        canObjs2.Add(canvas2);
        canObjs2.Add(canvas2v2);
        canvases.Add(2, canObjs2);

        List<GameObject> gameObjs3 = new List<GameObject>();
        gameObjs3.Add(gameUi3);
        gameObjs3.Add(gameController3);
        gameObjs3.Add(exit3);
        gameObjs3.Add(gameUi3v2);
        gameObjs3.Add(gameController3v2);
        gameObjs3.Add(exit3v2);
        gameObjStorage.Add(3, gameObjs3);
        List<Camera> camObjs3 = new List<Camera>();
        camObjs3.Add(gameCamera3);
        camObjs3.Add(gameCamera3v2);
        cameras.Add(3, camObjs3);
        List<Canvas> canObjs3 = new List<Canvas>();
        canObjs3.Add(canvas3);
        canObjs3.Add(canvas3v2);
        canvases.Add(3, canObjs3);

        List<GameObject> gameObjs4 = new List<GameObject>();
        gameObjs4.Add(gameUi4);
        gameObjs4.Add(gameController4);
        gameObjs4.Add(exit4);
        gameObjs4.Add(gameUi4v2);
        gameObjs4.Add(gameController4v2);
        gameObjs4.Add(exit4v2);
        gameObjStorage.Add(4, gameObjs4);
        List<Camera> camObjs4 = new List<Camera>();
        camObjs4.Add(gameCamera4);
        camObjs4.Add(gameCamera4v2);
        cameras.Add(4, camObjs4);
        List<Canvas> canObjs4 = new List<Canvas>();
        canObjs4.Add(canvas4);
        canObjs4.Add(canvas4v2);
        canvases.Add(4, canObjs4);

        List<GameObject> gameObjs5 = new List<GameObject>();
        gameObjs5.Add(gameUi5);
        gameObjs5.Add(gameController5);
        gameObjs5.Add(exit5);
        gameObjs5.Add(gameUi5v2);
        gameObjs5.Add(gameController5v2);
        gameObjs5.Add(exit5v2);
        gameObjStorage.Add(5, gameObjs5);
        List<Camera> camObjs5 = new List<Camera>();
        camObjs5.Add(gameCamera5);
        camObjs5.Add(gameCamera5v2);
        cameras.Add(5, camObjs5);
        List<Canvas> canObjs5 = new List<Canvas>();
        canObjs5.Add(canvas5);
        canObjs5.Add(canvas5v2);
        canvases.Add(5, canObjs5);

        List<GameObject> gameObjs6 = new List<GameObject>();
        gameObjs6.Add(gameUi6);
        gameObjs6.Add(gameController6);
        gameObjs6.Add(exit6);
        gameObjs6.Add(gameUi6v2);
        gameObjs6.Add(gameController6v2);
        gameObjs6.Add(exit6v2);
        gameObjStorage.Add(6, gameObjs6);
        List<Camera> camObjs6 = new List<Camera>();
        camObjs6.Add(gameCamera6);
        camObjs6.Add(gameCamera6v2);
        cameras.Add(6, camObjs6);
        List<Canvas> canObjs6 = new List<Canvas>();
        canObjs6.Add(canvas6);
        canObjs6.Add(canvas6v2);
        canvases.Add(6, canObjs6);

        List<GameObject> gameObjs71 = new List<GameObject>();
        gameObjs71.Add(gameUi71);
        gameObjs71.Add(gameController71);
        gameObjs71.Add(exit71);
        gameObjs71.Add(gameUi71v2);
        gameObjs71.Add(gameController71v2);
        gameObjs71.Add(exit71v2);
        gameObjStorage.Add(71, gameObjs71);
        List<Camera> camObjs71 = new List<Camera>();
        camObjs71.Add(gameCamera71);
        camObjs71.Add(gameCamera71v2);
        cameras.Add(71, camObjs71);
        List<Canvas> canObjs71 = new List<Canvas>();
        canObjs71.Add(canvas71);
        canObjs71.Add(canvas71v2);
        canvases.Add(71, canObjs71);

        List<GameObject> gameObjs72 = new List<GameObject>();
        gameObjs72.Add(gameUi72);
        gameObjs72.Add(gameController72);
        gameObjs72.Add(exit72);
        gameObjs72.Add(gameUi72v2);
        gameObjs72.Add(gameController72v2);
        gameObjs72.Add(exit72v2);
        gameObjStorage.Add(72, gameObjs72);
        List<Camera> camObjs72 = new List<Camera>();
        camObjs72.Add(gameCamera72);
        camObjs72.Add(gameCamera72v2);
        cameras.Add(72, camObjs72);
        List<Canvas> canObjs72 = new List<Canvas>();
        canObjs72.Add(canvas72);
        canObjs72.Add(canvas72v2);
        canvases.Add(72, canObjs72);

        List<GameObject> gameObjs8 = new List<GameObject>();
        gameObjs8.Add(gameUi8);
        gameObjs8.Add(gameController8);
        gameObjs8.Add(exit8);
        gameObjs8.Add(gameUi8v2);
        gameObjs8.Add(gameController8v2);
        gameObjs8.Add(exit8v2);
        gameObjStorage.Add(8, gameObjs8);
        List<Camera> camObjs8 = new List<Camera>();
        camObjs8.Add(gameCamera8);
        camObjs8.Add(gameCamera8v2);
        cameras.Add(8, camObjs8);
        List<Canvas> canObjs8 = new List<Canvas>();
        canObjs8.Add(canvas8);
        canObjs8.Add(canvas8v2);
        canvases.Add(8, canObjs8);

        List<GameObject> gameObjs9 = new List<GameObject>();
        gameObjs9.Add(gameUi9);
        gameObjs9.Add(gameController9);
        gameObjs9.Add(exit9);
        gameObjs9.Add(gameUi9v2);
        gameObjs9.Add(gameController9v2);
        gameObjs9.Add(exit9v2);
        gameObjStorage.Add(9, gameObjs9);
        List<Camera> camObjs9 = new List<Camera>();
        camObjs9.Add(gameCamera9);
        camObjs9.Add(gameCamera9v2);
        cameras.Add(9, camObjs9);
        List<Canvas> canObjs9 = new List<Canvas>();
        canObjs9.Add(canvas9);
        canObjs9.Add(canvas9v2);
        canvases.Add(9, canObjs9);

        List<GameObject> gameObjs10 = new List<GameObject>();
        gameObjs10.Add(gameUi10);
        gameObjs10.Add(gameController10);
        gameObjs10.Add(exit10);
        gameObjs10.Add(gameUi10v2);
        gameObjs10.Add(gameController10v2);
        gameObjs10.Add(exit10v2);
        gameObjStorage.Add(10, gameObjs10);
        List<Camera> camObjs10 = new List<Camera>();
        camObjs10.Add(gameCamera10);
        camObjs10.Add(gameCamera10v2);
        cameras.Add(10, camObjs10);
        List<Canvas> canObjs10 = new List<Canvas>();
        canObjs10.Add(canvas10);
        canObjs10.Add(canvas10v2);
        canvases.Add(10, canObjs10);

        List<GameObject> gameObjs11 = new List<GameObject>();
        gameObjs11.Add(gameUi11);
        gameObjs11.Add(gameController11);
        gameObjs11.Add(exit11);
        gameObjs11.Add(gameUi11v2);
        gameObjs11.Add(gameController11v2);
        gameObjs11.Add(exit11v2);
        gameObjStorage.Add(11, gameObjs11);
        List<Camera> camObjs11 = new List<Camera>();
        camObjs11.Add(gameCamera11);
        camObjs11.Add(gameCamera11v2);
        cameras.Add(11, camObjs11);
        List<Canvas> canObjs11 = new List<Canvas>();
        canObjs11.Add(canvas11);
        canObjs11.Add(canvas11v2);
        canvases.Add(11, canObjs11);

        List<GameObject> gameObjs12 = new List<GameObject>();
        gameObjs12.Add(gameUi12);
        gameObjs12.Add(gameController12);
        gameObjs12.Add(exit12);
        gameObjs12.Add(gameUi12v2);
        gameObjs12.Add(gameController12v2);
        gameObjs12.Add(exit12v2);
        gameObjStorage.Add(12, gameObjs12);
        List<Camera> camObjs12 = new List<Camera>();
        camObjs12.Add(gameCamera12);
        camObjs12.Add(gameCamera12v2);
        cameras.Add(12, camObjs12);
        List<Canvas> canObjs12 = new List<Canvas>();
        canObjs12.Add(canvas12);
        canObjs12.Add(canvas12v2);
        canvases.Add(12, canObjs12);
        GameManager.StateChanged += GameManagerOnStateChanged;
    }

    void OnDestroy()
    {
        GameManager.StateChanged -= GameManagerOnStateChanged;
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if(state == GameManager.GameState.DayBegin){
            if (GameManager.instance.dayNum == 7)
            {
                Debug.Log(GameManager.instance.ypz);
                if (GameManager.instance.ypz == 0)
                {
                    List<GameObject> gameObjs = gameObjStorage[71];
                    camTrigger.changeGame1(cameras[71][0], gameObjs[0], gameObjs[1]);
                    camTrigger.changeGame2(cameras[71][1], gameObjs[3], gameObjs[4]);
                    menuCamContr.changeGame1(cameras[71][0], gameObjs[0], gameObjs[1]);
                    menuCamContr.changeGame2(cameras[71][1], gameObjs[3], gameObjs[4]);
                    dialogueManager.changeMiniGamesCanvasAndExit(canvases[71][0], gameObjs[2],
                        canvases[71][1], gameObjs[5]);
                }
                else
                {
                    List<GameObject> gameObjs = gameObjStorage[72];
                    camTrigger.changeGame1(cameras[72][0], gameObjs[0], gameObjs[1]);
                    camTrigger.changeGame2(cameras[71][1], gameObjs[3], gameObjs[4]);
                    menuCamContr.changeGame1(cameras[72][0], gameObjs[0], gameObjs[1]);
                    menuCamContr.changeGame2(cameras[72][1], gameObjs[3], gameObjs[4]);
                    dialogueManager.changeMiniGamesCanvasAndExit(canvases[72][0], gameObjs[2],
                        canvases[72][1], gameObjs[5]);
                }
            }
            else
            {
                List<GameObject> gameObjs = gameObjStorage[GameManager.instance.dayNum];
                camTrigger.changeGame1(cameras[GameManager.instance.dayNum][0], gameObjs[0], gameObjs[1]);
                camTrigger.changeGame2(cameras[71][1], gameObjs[3], gameObjs[4]);
                menuCamContr.changeGame1(cameras[GameManager.instance.dayNum][0], gameObjs[0], gameObjs[1]);
                menuCamContr.changeGame2(cameras[GameManager.instance.dayNum][1], gameObjs[3], gameObjs[4]);
                dialogueManager.changeMiniGamesCanvasAndExit(canvases[GameManager.instance.dayNum][0], gameObjs[2],
                    canvases[GameManager.instance.dayNum][1], gameObjs[5]);
            }
        }
    }
}

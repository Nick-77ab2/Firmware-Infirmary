using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackoutSquare;
    public GameObject LoadingScreen;
    public GameObject playerBody;
    public GameObject playerCam;
    public Transform orientation;
    public OpenSignController lightswitch;
    private bool fadeToBlack=false;
    public float podX = 12.48f, podY = 0.18f, podZ = 3.162f, podRotationX = 0f, podRotationY = 360f;
    public float startX = -4.63f, startY = 0.056f, startZ = 9.583f, startRotationX = 0f, startRotationY = 0f;
    [SerializeField] private GameObject dayText;
    [SerializeField] private GameObject end1;
    [SerializeField] private GameObject end2;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject thankYou;
    [SerializeField] private PlayerMovement3D pm;
    [SerializeField] private MouseLook mouseLook;

    void Awake()
    {
        GameManager.StateChanged += GameManagerOnStateChanged;
        blackoutSquare.SetActive(true);
    }

    void OnDestroy()
    {
        GameManager.StateChanged -= GameManagerOnStateChanged;
    }

    private void GameManagerOnStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.MovingToPod || state == GameManager.GameState.Leaving || state == GameManager.GameState.DayEnd)
        {
            FadeOut();
        }
    }

    public void FadeOut()
    {
        StartCoroutine(Fade());
    }

    public IEnumerator Fade(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = blackoutSquare.GetComponent<Image>().color;
        float fadeAmount;

        pm.disableMovement();
        mouseLook.enabled = false;


        while (blackoutSquare.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackoutSquare.GetComponent<Image>().color = objectColor;
            yield return new WaitForSeconds(0.02f);
        }

        // CHECK IF DAY END AND MAKE IT START STUFF
        if (GameManager.instance.State == GameManager.GameState.DayEnd)
        {
            lightswitch.LightDisabled();
            if (SceneManager.GetActiveScene().name == "TutorialFromScrath")
            {
                LoadingScreen.SetActive(true);
                LoadingScreen.GetComponent<LoadingStarter>().loadStarter("Isabella_Enviro",false);
            }
            if(GameManager.instance.DayState != GameManager.DayGameState.Day12)
            {
                if (GameManager.instance.dayNum > 5)
                {
                    dayText.GetComponent<TextMeshProUGUI>().text = "Day " + (GameManager.instance.dayNum + 730).ToString();
                }
                else
                {
                    dayText.GetComponent<TextMeshProUGUI>().text = "Day " + GameManager.instance.dayNum.ToString();
                }
                if(SceneManager.GetActiveScene().name != "TutorialFromScrath"){
                    dayText.SetActive(true);
                }
                playerBody.transform.localPosition = new Vector3(startX, startY, startZ);
                playerCam.transform.rotation = Quaternion.Euler(startRotationX, startRotationY, 0);
                orientation.rotation = Quaternion.Euler(0, startRotationY, 0);
                orientation.parent.rotation = Quaternion.Euler(0, startRotationY, 0);

                yield return new WaitForSeconds(2f);
                if(SceneManager.GetActiveScene().name != "TutorialFromScrath"){
                    GameManager.instance.dayNum++;
                }
                GameManager.instance.UpdateDayGameState(GameManager.instance.dayStates[GameManager.instance.dayNum]);
                if (GameManager.instance.dayNum > 5)
                {
                    dayText.GetComponent<TextMeshProUGUI>().text = "Day " + (GameManager.instance.dayNum + 730).ToString();
                }
                else
                {
                    dayText.GetComponent<TextMeshProUGUI>().text = "Day " + GameManager.instance.dayNum.ToString();
                }
                yield return new WaitForSeconds(2f);
                dayText.SetActive(false);
                // ADD IN SOME RESET FOR GAMES OR OTHER
            }
            else
            {
                if (GameManager.instance.finalSuccess) 
                {
                    end1.GetComponent<TextMeshProUGUI>().text = "As Camilla leaves, you notice her posture. She's not sunk into her chair, like usual. She's sitting up straight, shoulders back, head high. Some truths are elusive. Has Greg brought you the cure? Or have you just bought her some time?";
                    end2.GetComponent<TextMeshProUGUI>().text = "Will MEDicil ever make it available for others? You can't know the answers. But, for the first time in a long time, it feels like there is a future here.";
                }
                else
                {
                    end1.GetComponent<TextMeshProUGUI>().text = "After her procedure, you give Camilla some hasty directions to Tusk's, hoping she can get there alright on her own. Before you close the door, you look at the Night District. There was once a buzz to this place.";
                    end2.GetComponent<TextMeshProUGUI>().text = "The sidewalks were dotted with street queens, cyborgs, club kids, the sorts of people you can only imagine. Now? This place, these people, are dying. Too few care for them at all, and even fewer care to act. Someday, there'll be a time for them. But not today. You close up shop.";
                }

                AkSoundEngine.StopAll();
                AkSoundEngine.PostEvent("Play_StreetAmbiance", playerCam);

                end1.SetActive(true);
                Color objectColor1 = end1.GetComponent<TextMeshProUGUI>().color;

                while (end1.GetComponent<TextMeshProUGUI>().color.a < 1)
                {
                    fadeAmount = objectColor1.a + (fadeSpeed * Time.deltaTime);

                    objectColor1 = new Color(objectColor1.r, objectColor1.g, objectColor1.b, fadeAmount);
                    end1.GetComponent<TextMeshProUGUI>().color = objectColor1;
                    yield return new WaitForSeconds(0.02f);
                }

                yield return new WaitForSeconds(5f);

                while (end1.GetComponent<TextMeshProUGUI>().color.a > 0)
                {
                    fadeAmount = objectColor1.a - (fadeSpeed * Time.deltaTime);

                    objectColor1 = new Color(objectColor1.r, objectColor1.g, objectColor1.b, fadeAmount);
                    end1.GetComponent<TextMeshProUGUI>().color = objectColor1;
                    yield return new WaitForSeconds(0.02f);
                }
                end1.SetActive(false);

                end2.SetActive(true);
                Color objectColor2 = end2.GetComponent<TextMeshProUGUI>().color;

                while (end2.GetComponent<TextMeshProUGUI>().color.a < 1)
                {
                    fadeAmount = objectColor2.a + (fadeSpeed * Time.deltaTime);

                    objectColor2 = new Color(objectColor2.r, objectColor2.g, objectColor2.b, fadeAmount);
                    end2.GetComponent<TextMeshProUGUI>().color = objectColor2;
                    yield return new WaitForSeconds(0.02f);
                }

                yield return new WaitForSeconds(5f);

                while (end2.GetComponent<TextMeshProUGUI>().color.a > 0)
                {
                    fadeAmount = objectColor2.a - (fadeSpeed * Time.deltaTime);

                    objectColor2 = new Color(objectColor2.r, objectColor2.g, objectColor2.b, fadeAmount);
                    end2.GetComponent<TextMeshProUGUI>().color = objectColor2;
                    yield return new WaitForSeconds(0.02f);
                }
                end2.SetActive(false);

                AkSoundEngine.StopAll();
                GameObject.Find("AudioManager").GetComponent<AudioManager>().fadeToBlack = true;

                // start animation for credits
                credits.SetActive(true);
                yield return new WaitForSeconds(30f);
                credits.SetActive(false);

                // after animation, fade in thank you
                thankYou.SetActive(true);
                Color objectColor3 = end2.GetComponent<TextMeshProUGUI>().color;

                while (thankYou.GetComponent<TextMeshProUGUI>().color.a < 1)
                {
                    fadeAmount = objectColor3.a + (fadeSpeed * Time.deltaTime);

                    objectColor3 = new Color(objectColor3.r, objectColor3.g, objectColor3.b, fadeAmount);
                    thankYou.GetComponent<TextMeshProUGUI>().color = objectColor3;
                    yield return new WaitForSeconds(0.02f);
                }

                yield return new WaitForSeconds(5f);

                AkSoundEngine.StopAll();

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                LoadScene ls = new LoadScene();
                ls.delSave = true;
                ls.loadScene("Start_Menu");
            }
        }
        else
        {
            playerBody.transform.localPosition = new Vector3(podX, podY, podZ);
            playerCam.transform.rotation = Quaternion.Euler(podRotationX, podRotationY, 0);
            orientation.rotation = Quaternion.Euler(0, podRotationY, 0);
            orientation.parent.rotation = Quaternion.Euler(0, podRotationY, 0);
        }

        // Change state so patient leaves while faded out
        if (GameManager.instance.State == GameManager.GameState.Leaving)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.DaySummary);
        }


        while (blackoutSquare.GetComponent<Image>().color.a > 0) {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackoutSquare.GetComponent<Image>().color = objectColor;
            yield return new WaitForSeconds(0.02f);
        }

        // CHECK IF DAY END AND MAKE IT START STUFF
        if (GameManager.instance.State == GameManager.GameState.DayEnd)
        {
            pm.enableMovement();
            mouseLook.yRotation = startRotationY;
            mouseLook.xRotation = startRotationX;
            mouseLook.enabled = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Init);
        }
        else
        {
            pm.enableMovement();
            mouseLook.yRotation = podRotationY;
            mouseLook.xRotation = podRotationX;
            mouseLook.enabled = true;
        }

        // Change state so mini game select cam enabled
        if (GameManager.instance.State == GameManager.GameState.MovingToPod)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.InPod);
        }
    }

    public IEnumerator FailFadeCoroutine()
    {
        Color objectColor = blackoutSquare.GetComponent<Image>().color;
        float fadeAmount;
        float fadeSpeed = 5;

        pm.disableMovement();
        mouseLook.enabled = false;

        while (blackoutSquare.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            blackoutSquare.GetComponent<Image>().color = objectColor;
            yield return new WaitForSeconds(0.02f);
        }

        dayText.GetComponent<TextMeshProUGUI>().text = "Their circuitry shorts, shocking their system. A critical failure.\nLet's do it right this time.";
        dayText.SetActive(true);
    }
}

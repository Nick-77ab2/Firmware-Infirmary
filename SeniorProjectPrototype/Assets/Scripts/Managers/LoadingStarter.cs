using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class LoadingStarter : MonoBehaviour
{
    public GameObject panel;
    public Slider loadingSlider;
    // Start is called before the first frame update
    void Start()
    {
        loadingSlider.value=0;
    }
    public void loadStarter(string sceneName, bool delSave){
        if (delSave) 
        {
            if (File.Exists(Application.dataPath + "/tempSave.txt"))
            {
                File.Delete(Application.dataPath + "/tempSave.txt");
            }
        }
        if(sceneName=="TutorialFromScrath"){
            GameObject.Find("Loading").GetComponent<TextMeshProUGUI>().text = "Loading Tutorial";
        }
        else if(sceneName == "Isabella_Enviro"){
            GameObject.Find("Loading").GetComponent<TextMeshProUGUI>().text = "Loading Firmware Infirmary";
        }
        else{
            GameObject.Find("Loading").GetComponent<TextMeshProUGUI>().text = "Loading";
        }
        panel.SetActive(false);
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        //Don't let the Scene activate until you allow it to
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";
            float progressValue = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            //Debug.Log("Progress: " + progressValue);

            loadingSlider.value = progressValue;
            // Check if the load has finished
            if(asyncOperation.progress==0.9f){

                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopMusic();
            }
            yield return null;
        }
    }
}

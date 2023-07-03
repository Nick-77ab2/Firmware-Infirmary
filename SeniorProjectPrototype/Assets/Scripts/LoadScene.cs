using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadScene : MonoBehaviour
{
    public bool delSave;

    public void loadScene(string sceneName){
        AkSoundEngine.StopAll();
        //Destroy(GameObject.Find("WwiseGlobal"));
        SceneManager.LoadScene(sceneName);
        if (delSave) 
        {
            if (File.Exists(Application.dataPath + "/tempSave.txt"))
            {
                File.Delete(Application.dataPath + "/tempSave.txt");
            }
        }
    }
}

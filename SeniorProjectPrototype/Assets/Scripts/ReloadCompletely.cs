using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class ReloadCompletely : MonoBehaviour
{
    DrawLine draw;
    public void reloadScene(){
        try{
            draw = GameObject.Find("PaintController").GetComponent<DrawLine>();
            draw.ResetCursor();
        }
        catch{
            Debug.LogWarning("Failed to find PaintController. Whoopsie.");
        }
        if (File.Exists(Application.dataPath + "/tempSave.txt"))
        {
            File.Delete(Application.dataPath + "/tempSave.txt");
        }
        AkSoundEngine.StopAll();
        //Destroy(GameObject.Find("WwiseGlobal"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

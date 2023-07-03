using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    DrawLine draw;
    public void reloadScene(){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        AkSoundEngine.StopAll();
        //Destroy(GameObject.Find("WwiseGlobal"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

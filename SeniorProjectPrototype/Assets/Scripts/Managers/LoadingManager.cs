//This script lets you load a Scene asynchronously. It uses an asyncOperation to calculate the progress and outputs the current progress to Text (could also be used to make progress bars).

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LoadingManager : MonoBehaviour
{
    private Button m_Button;
    public LoadingStarter loadStarter;

    void Start()
    {
        m_Button=this.gameObject.GetComponent<Button>();
        m_Button.onClick.AddListener(LoadButton);
    }

    public void LoadButton()
    {
        //Start loading the Scene asynchronously and output the progress bar
        if(this.gameObject.name == "Resume"){
            loadStarter.loadStarter("Isabella_Enviro", false);
            //StartCoroutine(LoadScene("Isabella_Enviro", false));
            Debug.LogWarning("Found Resume");
        }
        else{
            loadStarter.loadStarter("TutorialFromScrath",true);
            //StartCoroutine(LoadScene("TutorialFromScrath",true));
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ForceMouseSensitivity : MonoBehaviour
{
    public Slider slider;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public GameObject Resume;
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(Application.dataPath + "/tempSave.txt")){
            Resume.SetActive(true);
        }
        if (!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            PlayerPrefs.SetFloat("MouseSensitivity", 200f);
            Debug.Log(PlayerPrefs.GetFloat("MouseSensitivity"));
        }
        Debug.Log(PlayerPrefs.GetFloat("MouseSensitivity") + " Playerprefs has a mouse sensitivity.");
        slider.value=PlayerPrefs.GetFloat("MouseSensitivity");
         if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 50f);
            Debug.Log(PlayerPrefs.GetFloat("BGMVolume"));
        }
        BGMSlider.value=PlayerPrefs.GetFloat("BGMVolume");


        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 100f);
            Debug.Log(PlayerPrefs.GetFloat("SFXVolume"));
        }
        SFXSlider.value=PlayerPrefs.GetFloat("SFXVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

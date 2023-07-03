using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
//testingChanges
public class SettingsMenu : MonoBehaviour
{
    public Slider SensitivitySlider;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject playercam;
    public TMPro.TMP_Dropdown graphicsDropdown;

    [SerializeField]
    private AK.Wwise.RTPC BGMVol;
    [SerializeField]
    private AK.Wwise.RTPC SFXVol;
    [SerializeField]
    private float BGMVolumeValue;
    [SerializeField]
    private float SFXVolumeValue;
    void Start (){
        graphicsDropdown=this.transform.GetChild(3).gameObject.GetComponent<TMP_Dropdown>();
        if(!PlayerPrefs.HasKey("MouseSensitivity"))
        {
            PlayerPrefs.SetFloat("MouseSensitivity", 400f);
            Debug.Log(PlayerPrefs.GetFloat("MouseSensitivity"));
        }
        SensitivitySlider.value=PlayerPrefs.GetFloat("MouseSensitivity");

        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat("BGMVolume", 50f);
            Debug.Log(PlayerPrefs.GetFloat("BGMVolume"));
        }
        BGMSlider.value=PlayerPrefs.GetFloat("BGMVolume");
         if(BGMVol.GetGlobalValue()!=BGMSlider.value){
            BGMVol.SetGlobalValue(BGMSlider.value);
        }


        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 100f);
            Debug.Log(PlayerPrefs.GetFloat("SFXVolume"));
        }
        SFXSlider.value=PlayerPrefs.GetFloat("SFXVolume");
        if(SFXVol.GetGlobalValue()!=SFXSlider.value){
            SFXVol.SetGlobalValue(SFXSlider.value);
        }


        resolutions = Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height, refreshRate = Screen.currentResolution.refreshRate}).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if(resolutions[i].width== Screen.currentResolution.width && resolutions[i].height== Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        int qualityLevel = QualitySettings.GetQualityLevel();
        graphicsDropdown.value = qualityLevel;
        QualitySettings.SetQualityLevel(qualityLevel);

    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetBGMVolume(){
        BGMVolumeValue = BGMSlider.value;
        BGMVol.SetGlobalValue(BGMVolumeValue);
        PlayerPrefs.SetFloat("BGMVolume", BGMSlider.value);
    }

    public void SetSFXVolume(){
        SFXVolumeValue = SFXSlider.value;
        SFXVol.SetGlobalValue(SFXVolumeValue);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
    public void SetMouseSensitivity(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name!="Start_Menu" && scene.name!= "ESC_Menu"){
            float sensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
            playercam.GetComponent<MouseLook>().ChangeSensitivity(sensitivity);
        }
    }
    public void SaveSensitivity(){
        PlayerPrefs.SetFloat("MouseSensitivity",SensitivitySlider.value);
        SetMouseSensitivity();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    public KeyCode key = KeyCode.N;
    public TMP_Text DayText;
    private float timer = 0.0f;
    public float waitingTime = 4.0f;
    private bool finished=false;
    private bool dayStateWasActive=false;
    private bool currentDayActive=false;
    private bool ignored=false;
    DrawLine draw;
    // Update is called once per frame
    void Update()
    {
        if(!ignored && DayText.gameObject.activeSelf==true){
            dayStateWasActive=true;
        }
        else{
            ignored=true;
        }
        if(!dayStateWasActive && !currentDayActive){
            if(SceneManager.GetActiveScene().name == "TutorialFromScrath"){
                DayText.GetComponent<TextMeshProUGUI>().text = "Day " + (GameManager.instance.dayNum -1).ToString();
                Debug.LogWarning("NextDay is being called.");
            }
            else if(GameManager.instance.dayNum > 5){
               DayText.GetComponent<TextMeshProUGUI>().text= "Day "+ (GameManager.instance.dayNum + 730);
            }else{
                DayText.GetComponent<TextMeshProUGUI>().text= "Day "+ GameManager.instance.dayNum;
            }
            DayText.gameObject.SetActive(true);
            currentDayActive=true;
        }
        if(currentDayActive && !finished){
            timer+=Time.deltaTime;
            if(timer>=waitingTime){
                timer=0f;
                DayText.gameObject.SetActive(false);
                finished=true;
            }
        }
        if(Input.GetKeyDown(key) && DayText.gameObject.activeSelf==false) {
            Save();
            try{
                draw = GameObject.Find("PaintController").GetComponent<DrawLine>();
                draw.ResetCursor();
            }
            catch{
                Debug.LogWarning("Failed to find PaintController. Whoopsie.");
            }
            AkSoundEngine.StopAll();
            //Destroy(GameObject.Find("WwiseGlobal"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    /* Deprecated.
    public static void Load()
    {
        if (System.IO.File.Exists(Application.dataPath + "/tempSave.txt"))
        {
            string sep = ",";
            string save = System.IO.File.ReadAllText(Application.dataPath + "/tempSave.txt");

            string[] saveFileContents = save.Split(sep);
            GameManager.instance.dayNum = System.Int32.Parse(saveFileContents[0]);
            GameManager.instance.UpdateDayGameState(GameManager.instance.dayStates[GameManager.instance.dayNum]);
            GameManager.instance.color = saveFileContents[1];
            GameManager.instance.ypz = System.Int32.Parse(saveFileContents[2]);
            GameManager.instance.moods["Tusk"] = System.Int32.Parse(saveFileContents[3]);
            GameManager.instance.moods["Camilla"] = System.Int32.Parse(saveFileContents[4]);
            GameManager.instance.UpdateGameState(GameManager.GameState.DayBegin);
        }
    }
    */

    public static void Save()
    {
        string sep = ",";
        var NextDay = GameManager.instance.dayNum;
        NextDay+=1;
        if(NextDay>7 && (GameManager.instance.color =="" || GameManager.instance.color == null) ){
            GameManager.instance.color="Green";
        }
        if(NextDay>1 && GameManager.instance.moods["Camilla"]==0){
            GameManager.instance.moods["Camilla"]=2;
        }
        string[] savefileContents = new string[] {
            "" + NextDay,
            "" + GameManager.instance.color,
            "" + GameManager.instance.ypz,
            "" + GameManager.instance.moods["Tusk"],
            "" + GameManager.instance.moods["Camilla"]
        };


        string save = string.Join(sep, savefileContents);
        System.IO.File.WriteAllText(Application.dataPath + "/tempSave.txt", save);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DayReset : MonoBehaviour
{
    public static void Load()
    {
        Debug.LogWarning("Loading Scene...");
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

            Debug.Log("The new val" + GameManager.instance.color);
            Debug.Log("The load val" + saveFileContents[1]);
        }
        GameManager.instance.UpdateGameState(GameManager.GameState.DayBegin);
    }

    public static void Save()
    {
        string sep = ",";
        string[] savefileContents = new string[] {
            "" + GameManager.instance.dayNum,
            "" + GameManager.instance.color,
            "" + GameManager.instance.ypz,
            "" + GameManager.instance.moods["Tusk"],
            "" + GameManager.instance.moods["Camilla"]
        };


        string save = string.Join(sep, savefileContents);
        System.IO.File.WriteAllText(Application.dataPath + "/tempSave.txt", save);
    }
}

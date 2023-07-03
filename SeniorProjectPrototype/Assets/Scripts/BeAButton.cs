using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeAButton : MonoBehaviour
{
    public PaintManager pm;
    Button imAButton;

    void Start(){
        imAButton = this.GetComponent<Button>();
        imAButton.onClick.AddListener(TaskOnClick);
    }
    // Update is called once per frame
    void TaskOnClick()
    {
        pm.GameOver();
    }
}

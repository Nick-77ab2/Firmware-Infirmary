using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowSliderValue : MonoBehaviour
{
    public Slider slider;
    private TextMeshProUGUI theText;
    // Start is called before the first frame update
    void Start()
    {
        theText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeValue(slider.value);
    }

    public void ChangeValue(float value){
        theText.SetText(value.ToString());
    }
}

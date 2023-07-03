using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragTimer : MonoBehaviour
{
    public Slider meter;
    public float fullTime=1000f;
    // [SerializeField] SnapController snapController;

    void Start()
    {
        meter = this.transform.parent.transform.parent.GetComponent<Slider>();
    }

    // Update is called once per frame
    public void Drag(int timeDragged)
    {
        // if(drag.beingDragged){
        //     meter.fillAmount -= .001f;
        // }
        meter.value = 1 - (timeDragged / fullTime);
    }


}

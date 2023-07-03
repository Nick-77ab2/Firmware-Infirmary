using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineMeter : MonoBehaviour
{
    private Slider meter;

    void Start()
    {
        meter = this.transform.parent.transform.parent.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        int paintUsed = (PaintManager.instance.hitPaint + PaintManager.instance.missPaint);
        float percent = (float) paintUsed / (float) PaintManager.instance.maxPaint;
        float fill = 1- percent;
        if(fill == 1f){
            fill = .99f;
        }
        meter.value = fill;
    }
}

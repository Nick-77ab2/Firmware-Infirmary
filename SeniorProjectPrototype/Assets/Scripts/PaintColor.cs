using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaintColor : MonoBehaviour
{

    [SerializeField] GameObject drawCanvas;
    [SerializeField] GameObject paintCanvas;
    [SerializeField] GameObject drawController;
    [SerializeField] GameObject line;
    [SerializeField] Image myColor;
    [SerializeField] Image desiredColor;
    [SerializeField] Image inkMeter;
    private float tempColor;
    bool isSuccess;
    private NewDialogueScript script;
    private DialogueManager manager;

    public void Awake(){
        myColor.color = new Color((float) 0, (float) 0, (float) 0, (float) 1);
        if (GameManager.instance.dayNum != 11  && GameManager.instance.dayNum >= 7)
        {
             Debug.LogWarning("You've made it to the cum zone.");
            if(GameManager.instance.color == "Orange")
            {
                desiredColor.color = new Color((float) 1, (float) .6, (float) .0, (float) 1);
            }
            else if(GameManager.instance.color == "Violet")
            {
                desiredColor.color = new Color((float) .4, (float) .2, (float) .6, (float) 1);
            }
            else if(GameManager.instance.color == "Green")
            {
                desiredColor.color = new Color((float) 0, (float) 1, (float) 0, (float) 1);
            }
            else if(GameManager.instance.color == "Yellow")
            {
                desiredColor.color = new Color((float) 1, (float) 1, (float) 0, (float) 1);
            }
            else if(GameManager.instance.color == "Red")
            {
                desiredColor.color = new Color((float) 1, (float) .0, (float) .0, (float) 1);
            }
            else if(GameManager.instance.color == "Purple")
            {
                desiredColor.color = new Color((float) .6, (float) .2, (float) 1, (float) 1);
            }
            else
            {
                int red = Random.Range(0, 5);
                int green = Random.Range(0, 5);
                int blue = Random.Range(0, 5);
                desiredColor.color = new Color((float) .2 * red, (float) .2 * green, (float) .2 * blue, (float) 1);
            }
        }
        else 
        {
            int red = Random.Range(0, 5);
            int green = Random.Range(0, 5);
            int blue = Random.Range(0, 5);
            desiredColor.color = new Color((float) .2 * red, (float) .2 * green, (float) .2 * blue, (float) 1);
        }
        Debug.Log(desiredColor.color);
        isSuccess = false;
        int dred = (int) (desiredColor.color.r * 10);
        int dgreen = (int) (desiredColor.color.g * 10);
        int dblue = (int) (desiredColor.color.b * 10);
        int mred = (int) (myColor.color.r * 10);
        int mgreen = (int) (myColor.color.g * 10);
        int mblue = (int) (myColor.color.b * 10);

        GameObject.Find("DesiredColorRGB").GetComponent<TMP_Text>().text = ("R: " +  dred.ToString() + " G: " + dgreen.ToString() + " B: " + dblue.ToString());
        GameObject.Find("CurrentColorRGB").GetComponent<TMP_Text>().text = ("R: " +  mred.ToString() + " G: " + mgreen.ToString() + " B: " + mblue.ToString());
    }

    public void SaveColor(){
        float diff = 0.0f;
        diff += Mathf.Abs(desiredColor.color.r - myColor.color.r);
        diff += Mathf.Abs(desiredColor.color.g - myColor.color.g);
        diff += Mathf.Abs(desiredColor.color.b - myColor.color.b);

        if(diff < .3f){
            drawCanvas.SetActive(true);
            paintCanvas.SetActive(false);
            isSuccess = true;
            script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
            script.isSuccess = true;
            StartCoroutine(WaitAndSet());
            drawController.GetComponent<DrawLine>().enabled = true;
            Gradient gradient = new  Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(myColor.color, 0.0f), new GradientColorKey(myColor.color, 1.0f)},
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f)}
            );
            line.GetComponent<LineRenderer>().colorGradient = gradient;
            inkMeter.color = myColor.color;
            GameObject.Find("PaintController").GetComponent<DrawLine>().ChangeCursorColor(myColor);
            GameObject.Find("MousePainter").GetComponent<MousePainter>().paintColor = myColor.color;
        }else{
            Debug.Log("no");
        }
    }

    IEnumerator WaitAndSet(){
        yield return new WaitForSeconds(.1f);
        script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
        script.isSuccess = false;
    }

    public void ResetColor(){
        myColor.color = new Color((float) 0, (float) 0, (float) 0, (float) 1);
        setCurrentColorText();
    }

    public void AddRed(){
        tempColor = .2f + (float) myColor.color.r;
        if(tempColor > 1f){
            tempColor = 1f;
        }
        myColor.color = new Color(tempColor,(float) myColor.color.g,(float) myColor.color.b,(float) myColor.color.a);
        Debug.Log(myColor.color);
        setCurrentColorText();
    }

    public void AddGreen(){
        tempColor = .2f + (float) myColor.color.g;
        if(tempColor > 1f){
            tempColor = 1f;
        }
        myColor.color = new Color((float) myColor.color.r,tempColor,(float) myColor.color.b,(float) myColor.color.a);
        Debug.Log(myColor.color);
        setCurrentColorText();
    }

    public void AddBlue(){
        tempColor = .2f + (float) myColor.color.b;
        if(tempColor > 1f){
            tempColor = 1f;
        }
        myColor.color = new Color((float) myColor.color.r,(float) myColor.color.g,tempColor,(float) myColor.color.a);
        Debug.Log(myColor.color);
        setCurrentColorText();
    }

    public void AddWhite(){
        tempColor = .2f + (float) myColor.color.r;
        if(tempColor > 1f){
            tempColor = 1f;
        }
        myColor.color = new Color(tempColor,(float) myColor.color.g,(float) myColor.color.b,(float) myColor.color.a);
        tempColor = .2f + (float) myColor.color.g;
        if(tempColor > 1f){
            tempColor = 1f;
        }
        myColor.color = new Color((float) myColor.color.r,tempColor,(float) myColor.color.b,(float) myColor.color.a);
        tempColor = .2f + (float) myColor.color.b;
        if(tempColor > 1f){
            tempColor = 1f;
        }
        myColor.color = new Color((float) myColor.color.r,(float) myColor.color.g,tempColor,(float) myColor.color.a);
        Debug.Log(myColor.color);
        setCurrentColorText();
    }

    public void AddBlack(){
        tempColor = (float) myColor.color.r - .2f;
        if(tempColor < 0f){
            tempColor = 0f;
        }
        myColor.color = new Color(tempColor,(float) myColor.color.g,(float) myColor.color.b,(float) myColor.color.a);
        tempColor = (float) myColor.color.g - .2f;
        if(tempColor < 0f){
            tempColor = 0f;
        }
        myColor.color = new Color((float) myColor.color.r,tempColor,(float) myColor.color.b,(float) myColor.color.a);
        tempColor = (float) myColor.color.b - .2f;
        if(tempColor < 0f){
            tempColor = 0f;
        }
        myColor.color = new Color((float) myColor.color.r,(float) myColor.color.g,tempColor,(float) myColor.color.a);
        Debug.Log(myColor.color);
        setCurrentColorText();
    }

    public void setCurrentColorText(){
        int mred = (int) (myColor.color.r * 10);
        int mgreen = (int) (myColor.color.g * 10);
        int mblue = (int) (myColor.color.b * 10);

        GameObject.Find("CurrentColorRGB").GetComponent<TMP_Text>().text = ("R: " +  mred.ToString() + " G: " + mgreen.ToString() + " B: " + mblue.ToString());
    }
}

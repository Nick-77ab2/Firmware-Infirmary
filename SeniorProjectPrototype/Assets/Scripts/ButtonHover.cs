using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public string audioHover = "Play_HoverSelection";
    public string audioSelection = "Play_OptionSelection";
    private Color color;
    public Color hoverColor;
    private Button button;

    private void Start()
    {
        GameObject newText = gameObject.transform.GetChild(0).gameObject;
        color = newText.GetComponent<TMP_Text>().color;
        button = this.gameObject.GetComponent<Button>();
        button.navigation = new Navigation() {mode = Navigation.Mode.None };
        hoverColor.a=1f;
    }

    public void PlayHover()
    {
        Debug.Log("Hovering");
        AkSoundEngine.PostEvent(audioHover, this.gameObject);

    }

    public void PlaySelect()
    {
        Debug.Log("Clicked");
        AkSoundEngine.PostEvent(audioSelection, this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject newText = gameObject.transform.GetChild(0).gameObject;
        newText.GetComponent<TMP_Text>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject newText = gameObject.transform.GetChild(0).gameObject;
        newText.GetComponent<TMP_Text>().color = color;
    }
    public void OnPointerClick(PointerEventData eventData){
        GameObject newText = gameObject.transform.GetChild(0).gameObject;
        newText.GetComponent<TMP_Text>().color = color;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    public delegate void DragEndedDelegate(Drag draggableObject);
    public DragEndedDelegate dragEndedCallback;
    public bool canDrag = true;
    public bool beingDragged = false;
    public bool isCorrect=true;
    public float timeDragged = 0;
    private ESCListen escListen;
    
    void Start(){
        escListen = GameObject.Find("MiscManager").GetComponent<ESCListen>();
    }

    public void DragHandler(BaseEventData data){
        if(canDrag && !escListen.escActive){
            timeDragged+=Time.deltaTime * 100;
            beingDragged = true;
            PointerEventData pointerData = (PointerEventData)data;
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position
            );

            transform.position = canvas.transform.TransformPoint(position);
        }
    }

    public void OnMouseUP(){
        if(canDrag && !escListen.escActive){
            beingDragged = false;
            dragEndedCallback(this);
        }
    }
}

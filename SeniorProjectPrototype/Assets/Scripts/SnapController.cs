using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Transform> snapPointsCopy;
    public List<Drag> draggableObjects;
    private List<Drag> snappedDrags = new List<Drag>();
    private int count = 0;
    private int i1=0;
    public GameObject theCanvas;
    public float snapRange = 500.0f;
    public bool isPart1 = false;
    private int piecesInPlace = 0;
    private int piecesMoved = 0;
    private bool zoomed = false;
    private bool part1Complete = false;
    [SerializeField] GameObject part1;
    [SerializeField] GameObject part2;
    [SerializeField] GameObject microChip;
    [SerializeField] GameObject arm;
    [SerializeField] GameObject emptyChip;
    [SerializeField] GameObject fullChip;
    [SerializeField] GameObject outline;
    [SerializeField] int numPieces = 0;
    private NewDialogueScript script;
    private bool dragReady = false;
    public int maxTimeDragged = 1000;
    public int timeDragged = 0;
    [SerializeField] GameObject timer;
    private bool failSent = false;
    private ESCListen escListen;
    // public static SnapController instance;
    // Start is called before the first frame update
    void Start()
    {
        escListen = GameObject.Find("MiscManager").GetComponent<ESCListen>();
        // instance = this;
    }
    void Update(){
        // if(snapPoints.Count != numPieces){
        //     AddSnaps();
        // }
        if(count==0 && theCanvas.active){
            Debug.Log("Canvas is active");
            count+=1;
            AddDrags();
            AddSnaps();
            script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
        }
        if(dragReady && theCanvas.active){
            float total = 0;
            for(int i=0; i<draggableObjects.Count; i++){
                total += draggableObjects[i].timeDragged;
            }
            timeDragged = (int) total;
            // Debug.Log(timeDragged);
            timer.GetComponent<DragTimer>().Drag(timeDragged);
            if(timer.GetComponent<DragTimer>().meter.value ==0 && !failSent){
                GameManager.instance.FailDay();
                Debug.Log("Fail was sent.");
                foreach(Drag drag in draggableObjects){
                    drag.canDrag=false;
                }
            }
        }
    }

    private void OnDragEnded(Drag draggable){
        snappedDrags.Remove(draggable);
        piecesMoved ++;
        // Debug.Log(piecesMoved);
        float closestDistance = -1;
        Transform closestSnapPoint = null;
        foreach(Transform snapPoint in snapPoints){
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if(closestSnapPoint == null){
                //AkSoundEngine.PostEvent("Play_Error", gameObject);
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }else{
                if("Snap" + System.Convert.ToInt32(draggable.name).ToString() == closestSnapPoint.name){
                    Debug.Log("override");
                }else{
                    if (currentDistance < closestDistance){
                        closestSnapPoint = snapPoint;
                        closestDistance = currentDistance;
                    }
                    if("Snap" + System.Convert.ToInt32(draggable.name).ToString() == snapPoint.name && currentDistance <= snapRange * 100){
                        closestSnapPoint = snapPoint;
                        closestDistance = currentDistance;
                    }
                }
            }
        }
        if(closestSnapPoint != null && closestDistance <= snapRange * 100){
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            MarkCovered(draggable, closestSnapPoint);
        }
        else{
            Debug.LogWarning("Played Error 1");
            AkSoundEngine.PostEvent("Play_Error", gameObject);
        }
    }

    private void AddSnaps(){
        Debug.Log("shanps");
        for(int i = 1; i < numPieces + 1; i++){
            snapPoints[i-1]=(theCanvas.transform.Find("Snap" + i.ToString()).GetComponent<Transform>());
        }
        snapPointsCopy = new List<Transform>(snapPoints);

        // for(int i=0; i<snapPoints.Count; i++){
        //         Debug.Log(snapPoints[i] + " " + i);
        //         Debug.Log("yo");
        //     }
    }

    private void AddDrags(){
        Debug.Log("Drags");
        for(int i = 1; i < numPieces + 1; i++){
            Debug.Log(i);
            if(i < 10){
                draggableObjects[i-1]=(theCanvas.transform.Find("0" + i.ToString()).GetComponent<Drag>());
            }else{
                draggableObjects[i-1]=(theCanvas.transform.Find(i.ToString()).GetComponent<Drag>());
            }
        }
        // for(int i=0; i<draggableObjects.Count; i++){
        //         Debug.Log(draggableObjects[i] + " " + i);
        //     }
        foreach(Drag draggable in draggableObjects){
                Debug.Log(draggable);
                Debug.Log("We creatin tho");
                if(draggable==null)
                {
                    Debug.Log("there was a null child!");
                    draggableObjects.Remove(draggable);
                }else{
                    draggable.dragEndedCallback = OnDragEnded;
                }
            }
        dragReady = true;
    }

    private void MarkCovered(Drag d, Transform snap){
        Debug.Log("WTF");
        if (snappedDrags.Contains(d) == false){
            Debug.Log("FML");
            snappedDrags.Add(d);
        }
        if(!(snapPointsCopy.IndexOf(snap)==draggableObjects.IndexOf(d))){
            //Debug.LogError("Snap: " + snap.name + " Drag: " + d.name + " Indexes (Snap, Drag): " + snapPoints.IndexOf(snap) + ", " + draggableObjects.IndexOf(d));
            AkSoundEngine.PostEvent("Play_Error", gameObject);
            Debug.LogWarning("Played Error");
        }
        if(snapPointsCopy.IndexOf(snap)==draggableObjects.IndexOf(d)){
            d.isCorrect=true;
            AkSoundEngine.PostEvent("Play_Success", this.gameObject);
            piecesInPlace++;
            d.canDrag = false;
            snapPoints.Remove(snap);
            SetDragHeirarchy();
        }
        /*switch (d.name){
            case "01":
                if(snap.name == "Snap1"){
                    d.isCorrect=true;
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "02":
                if(snap.name == "Snap2"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "03":
                if(snap.name == "Snap3"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "04":
                if(snap.name == "Snap4"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "05":
                if(snap.name == "Snap5"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "06":
                if(snap.name == "Snap6"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "07":
                if(snap.name == "Snap7"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "08":
                if(snap.name == "Snap8"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "09":
                if(snap.name == "Snap9"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "10":
                if(snap.name == "Snap10"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "11":
                if(snap.name == "Snap11"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "12":
                if(snap.name == "Snap12"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "13":
                if(snap.name == "Snap13"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "14":
                if(snap.name == "Snap14"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            case "15":
                if(snap.name == "Snap15"){
                    AkSoundEngine.PostEvent("Play_Success", this.gameObject);
                    piecesInPlace++;
                    d.canDrag = false;
                    snapPoints.Remove(snap);
                    SetDragHeirarchy();
                }
                break;
            default:
                AkSoundEngine.PostEvent("Play_Error", this.gameObject);
                break;
        }*/
        if(piecesInPlace == numPieces){
            if(part1){
                part1Complete = true;
                foreach(Drag drag in draggableObjects){
                    drag.canDrag=false;
                }
                gameObject.SetActive(false);
                Zoom();
            }else{
                Debug.Log("Win");
                fullChip.SetActive(true);
                emptyChip.SetActive(false);
                outline.SetActive(false);
                script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
                script.isSuccess = true;
            }
        }else if(snappedDrags.Count == numPieces){
            if(part1){
                part1Complete = true;
                foreach(Drag drag in draggableObjects){
                    drag.canDrag=false;
                }
                gameObject.SetActive(false);
                Zoom();
            }else{
                script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
                script.isFail = true;
                failSent = true;
                Debug.Log("Fail was sent.");
                foreach(Drag drag in draggableObjects){
                    drag.canDrag=false;
                }
            }
        }

    }

    public void SetDragHeirarchy(){
        foreach(Drag draggable in draggableObjects){
            Debug.Log(draggable.name);
            if(GameObject.Find(draggable.name).tag == "Bottom"){
                Debug.Log("Bottom");
                GameObject.Find(draggable.name).GetComponent<RectTransform>().SetAsLastSibling();
            }
        }
        foreach(Drag draggable in draggableObjects){
            if(GameObject.Find(draggable.name).tag == "Middle"){
                Debug.Log("Middle");
                GameObject.Find(draggable.name).GetComponent<RectTransform>().SetAsLastSibling();
            }
        }
        foreach(Drag draggable in draggableObjects){
            if(GameObject.Find(draggable.name).tag == "Top"){
                Debug.Log("Top");
                GameObject.Find(draggable.name).GetComponent<RectTransform>().SetAsLastSibling();
            }
        }
        foreach(Drag draggable in draggableObjects){
            if(draggable.canDrag){
                Debug.Log("Drag");
                GameObject.Find(draggable.name).GetComponent<RectTransform>().SetAsLastSibling();
            }
        }
    }

    public void Zoom(){
        if (zoomed){
            microChip.SetActive(false);
            arm.SetActive(true);
            zoomed = false;
            if(part1Complete){
                part1.SetActive(false);
                part2.SetActive(true);
            }
        }else{
            microChip.SetActive(true);
            arm.SetActive(false);
            zoomed = true;
        }
    }
}

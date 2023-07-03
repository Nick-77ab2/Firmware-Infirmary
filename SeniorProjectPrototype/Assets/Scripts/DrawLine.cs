using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawLine : MonoBehaviour
{
    private List<string> recordedPoints = new List<string>();
    private int exists = 0;
    private int outside = 0;
    public static DrawLine instance;
    public Camera currentCamera;
    public bool isSuccess = false;
    private bool refreshLine = false;
    private NewDialogueScript script;
    public Texture2D sprayCursor;
    public bool painting = false;
    private Texture2D _texture;
    private Image paintColor;

    [SerializeField] GameObject linePrefab;
    public GameObject currentLine; 
    private ESCListen escListen;
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    [SerializeField] List<Vector2> fingerPositions;

    private float _lineLength;
    public float lineLength{
        get{
            return _lineLength;
        }
    }

    [SerializeField] private float _maxLineLength;
    public float maxLineLength{
        get{
            return _maxLineLength;
        }
    }

    private int currentPoint;

    void Start() {
        instance = this;
        escListen = GameObject.Find("MiscManager").GetComponent<ESCListen>();
    }

    void Update(){
        if (_lineLength <= _maxLineLength && !isSuccess){
            Vector2 tempFingerPos = currentCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x+95,Input.mousePosition.y-6,Input.mousePosition.z));
            GameObject paintedObject = GameObject.Find("DrawCanvas");
            if(RectTransformUtility.RectangleContainsScreenPoint(paintedObject.GetComponent<RectTransform>(), tempFingerPos) && escListen.escActive==false){
                painting=true;
                if(painting){
                    Cursor.SetCursor(sprayCursor, new Vector2(70f,0f), CursorMode.ForceSoftware);
                    
                }
            }else{
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
                refreshLine = true;
                painting=false;
            }
        }else{
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            if(!isSuccess){
                // GameOver();
            }
        }
    }
    void CreateLine(){
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.transform.parent=GameObject.Find("SprayPaintMicroGame").transform;
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();
        fingerPositions.Add(currentCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x+95,Input.mousePosition.y-6,Input.mousePosition.z)));
        fingerPositions.Add(currentCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x+95,Input.mousePosition.y-6,Input.mousePosition.z)));
        lineRenderer.SetPosition(0, fingerPositions[0]);
        lineRenderer.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
        currentPoint = 2;
        RecordPoint(fingerPositions[0]);
    }

    void UpdateLine(Vector2 newFingerPos){
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount -1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();

        _lineLength += Vector2.Distance(fingerPositions[currentPoint], fingerPositions[currentPoint - 1]);
        RecordPoint(newFingerPos);
    }

    void RecordPoint(Vector2 newPoint){
        // Debug.Log(newPoint.ToString("F1"));
        GameObject paintedObject = GameObject.Find("PaintedObject");
        Vector3 newPoint3 = new Vector3(newPoint.x, newPoint.y, paintedObject.transform.position.z);
        // Debug.Log(paintedObject.GetComponent<SpriteRenderer>().bounds.Contains(newPoint3));
        if(recordedPoints.Contains(newPoint.ToString("F1"))){
            Debug.Log("exists");
            exists++;
        }
        else if(paintedObject.GetComponent<SpriteRenderer>().bounds.Contains(newPoint3)){
            recordedPoints.Add(newPoint.ToString("F1"));
            Debug.Log("added");
        }else{
            Debug.Log("outside");
            outside++;
        }
        // Debug.Log(recordedPoints.length);
    }

    public void GameOver(){

        Debug.Log("Game Over DL");
        int remaining = (int) (maxLineLength - lineLength);
        GameObject.Find("Scores").GetComponent<RectTransform>().SetAsLastSibling();
        GameObject.Find("RemainingPaint").GetComponent<TMP_Text>().text = "Remaining: " + remaining.ToString();
        GameObject.Find("CorrectPaint").GetComponent<TMP_Text>().text = "Correct: " + recordedPoints.Count.ToString();
        GameObject.Find("IncorrectPaint").GetComponent<TMP_Text>().text = "Incorrect: " + outside.ToString();
        isSuccess = true;
        script = GameObject.Find("DialogueScript(Clone)").GetComponent<NewDialogueScript>();
        script.isSuccess = true;
    }

    public void ChangeCursorColor(Image myColor){
        // sprayCursor.color = myColor.color;
        // _texture = (Texture2D)sprayCursor.GetComponent<Image>().sprite.texture;
        // _texture.Apply();
        // sprayCursor.enabled = false;
        // paintColor = myColor;
        SetTheCursor();
    }

    public void ResetCursor(){
        //MouseManager cursorManager = GameObject.Find("PlayerCamera").GetComponent<MouseManager>();
        //cursorManager.SetCursor();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        painting = false;
    }

    public void SetTheCursor()
    {
        Cursor.SetCursor(sprayCursor, new Vector2(70f,0f), CursorMode.ForceSoftware);
        painting = true;
    }
}

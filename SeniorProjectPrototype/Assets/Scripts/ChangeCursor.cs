using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{

    public Texture2D sprayCursor;
    
    void OnMouseEnter()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(sprayCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}

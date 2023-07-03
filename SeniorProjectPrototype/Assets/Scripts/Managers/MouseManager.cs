using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Texture2D cursor;
    public Vector3 positionOffset = Vector2.zero;
    public void SetCursor(){
        Cursor.SetCursor(cursor, positionOffset, CursorMode.ForceSoftware);
    }
}

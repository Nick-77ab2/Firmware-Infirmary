using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolArea : MonoBehaviour
{
   public bool mouseInToolBar=false;

   public bool getMouseInToolBar(){
      return mouseInToolBar;
   }
   public void mouseIsHover(){
      mouseInToolBar=true;
   }

   public void mouseIsntHover(){
      mouseInToolBar=false;
   }

}

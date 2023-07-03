using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    abstract public void Interact();

    abstract public void SetIsInteractable(bool value);
}

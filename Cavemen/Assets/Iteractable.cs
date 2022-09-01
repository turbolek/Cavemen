using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public Vector3 GetPosition();
    public bool IsInteractable();
    public void Interact();
}

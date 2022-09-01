using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStockpile : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Picked up resource");
    }

    public bool IsInteractable()
    {
        return true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

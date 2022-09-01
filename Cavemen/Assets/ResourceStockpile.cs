using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStockpile : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int _amount = 5;

    public void Interact()
    {
        Debug.Log("Picked up resource");
        _amount--;
        Debug.Log("Remaining amount: " + _amount);
        gameObject.SetActive(IsInteractable());
    }

    public bool IsInteractable()
    {
        return _amount > 0;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

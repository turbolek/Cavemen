using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStockpile : MonoBehaviour, IInteractable
{
    public static event Action<int> ResourcePickedUp;

    [SerializeField]
    private int _amount = 5;

    [SerializeField]
    private List<ResearchData> RequiredResearches = new List<ResearchData>();

    public void Interact()
    {
        PickupResource();
    }

    private void PickupResource()
    {
        Debug.Log("Picked up resource");
        _amount--;
        Debug.Log("Remaining amount: " + _amount);
        ResourcePickedUp?.Invoke(1);
        gameObject.SetActive(IsInteractable());
    }

    public bool IsInteractable()
    {
        return CheckRequiredResearches() && _amount > 0;
    }

    private bool CheckRequiredResearches()
    {
        return true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

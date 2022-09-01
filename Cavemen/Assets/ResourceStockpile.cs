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

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Interact()
    {
        if (CheckRequiredResearches())
        {
            PickupResource();
        }
        else
        {
            Debug.Log("Research required");
        }
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
        return _amount > 0;
    }

    private bool CheckRequiredResearches()
    {
        foreach (ResearchData researchData in RequiredResearches)
        {
            if (!playerController.CheckIfResearchUnlocked(researchData))
            {
                return false;
            }
        }

        return true;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}

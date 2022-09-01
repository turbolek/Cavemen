using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _resourcesValueLabel;

    private int _resourcesAmount = 0;
    public int ResourcesAmount { get; private set; }

    private void Start()
    {
        ResourceStockpile.ResourcePickedUp += OnResourcePickedUp;
        RefreshResourceLabel();
    }

    private void OnResourcePickedUp(int pickedUpAmount)
    {
        _resourcesAmount += pickedUpAmount;
        RefreshResourceLabel();
    }

    private void RefreshResourceLabel()
    {
        _resourcesValueLabel.text = _resourcesAmount.ToString();
    }

}

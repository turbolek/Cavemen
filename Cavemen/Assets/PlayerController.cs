using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _resourcesValueLabel;

    [SerializeField]
    private List<ResearchData> _availableResearches = new List<ResearchData>();

    [SerializeField]
    private Transform _researchButtonParent;
    [SerializeField]
    private ResearchButton _researchButtonPrefab;

    private List<ResearchData> _purchasedResearches = new List<ResearchData>();
    private List<ResearchButton> _researchButtons = new List<ResearchButton>();

    private int _resourcesAmount = 0;
    public int ResourcesAmount { get; private set; }

    private void Start()
    {
        ResourceStockpile.ResourcePickedUp += OnResourcePickedUp;
        SpawnResearchButtons();
        RefreshUI();
    }

    private void RefreshUI()
    {
        RefreshResourceLabel();
        RefreshResearchButtons();
    }

    private void OnResourcePickedUp(int pickedUpAmount)
    {
        _resourcesAmount += pickedUpAmount;
        RefreshUI();
    }

    private void RefreshResourceLabel()
    {
        _resourcesValueLabel.text = _resourcesAmount.ToString();
    }

    private void RefreshResearchButtons()
    {
        foreach (ResearchButton researchButton in _researchButtons)
        {
            researchButton.Refresh(_resourcesAmount);
        }
    }

    private void SpawnResearchButtons()
    {
        foreach (ResearchData data in _availableResearches)
        {
            ResearchButton researchButton = Instantiate(_researchButtonPrefab, _researchButtonParent);
            researchButton.Init(data, OnReseachButtonClicked);
            _researchButtons.Add(researchButton);
        }
    }

    private void OnReseachButtonClicked(ResearchButton button)
    {
        _resourcesAmount -= button.Data.Cost;
        _availableResearches.Add(button.Data);
        RefreshUI();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour
{
    [SerializeField]
    private Color _clickedColor;
    [SerializeField]
    private TMP_Text _nameLabel;

    private Button _button;
    public ResearchData Data { get; private set; }
    private Action<ResearchButton> _onClickCallback;

    private bool _clicked = false;

    public void Init(ResearchData data, Action<ResearchButton> onClickedCallback)
    {
        _button = GetComponent<Button>();
        Data = data;
        _nameLabel.text = Data.Name;
        _onClickCallback = onClickedCallback;
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _clicked = true;
        _button.GetComponent<Image>().color = _clickedColor;
        _onClickCallback?.Invoke(this);
    }

    public void Refresh(int resourceAmount)
    {
        _button.interactable = !_clicked && resourceAmount >= Data.Cost;
    }
}

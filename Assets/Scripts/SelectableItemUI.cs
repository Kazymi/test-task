using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class SelectableItemUI
{
    [SerializeField] private Image imageItem;
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text descriptionText;

    public Transform DesciptionTransform => descriptionText.transform;
    public Transform ImageTransform => imageItem.transform;
    public void SetButtonEvent(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public void SetImageAndDescription(Sprite sprite, string description)
    {
        imageItem.sprite = sprite;
        descriptionText.text = description;
    }

    public void SetButtonInteractable(bool isInteractable)
    {
        button.interactable = isInteractable;
    }
}
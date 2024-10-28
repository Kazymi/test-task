using System;
using UnityEngine;

[Serializable]
public class SelectableItemConfiguration
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
}
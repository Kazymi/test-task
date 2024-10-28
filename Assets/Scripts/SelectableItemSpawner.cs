using UnityEngine;

public class SelectableItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform layotParent;
    [SerializeField] private SelectableItem prefab;
    [SerializeField] private int amount;

    private void Start()
    {
        SpawnSelectableItems();
    }

    private void SpawnSelectableItems()
    {
        for (int i = 0; i < amount; i++)
        {
            var newItem = Instantiate(prefab, layotParent);
            newItem.Initialize();
        }
    }
}
using UnityEngine;

public class SelectableItemStorage : MonoBehaviour, ISelectableItemStorageService
{
    [SerializeField] private SelectableItemConfiguration[] selectableItemConfigurations;

    private void OnEnable()
    {
        ServiceLocator.Subscribe<ISelectableItemStorageService>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<ISelectableItemStorageService>();
    }

    public SelectableItemConfiguration GetRandomSelectableItemConfiguration()
    {
        return selectableItemConfigurations[Random.Range(0, selectableItemConfigurations.Length)];
    }
}
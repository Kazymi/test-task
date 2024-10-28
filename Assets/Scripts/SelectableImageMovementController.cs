using UnityEngine;

public class SelectableImageMovementController : MonoBehaviour,ISelectableImageMoverService
{
    [SerializeField] private Transform movementParent;
    [SerializeField] private RectTransform canvasForRandomPosition;

    private void OnEnable()
    {
        ServiceLocator.Subscribe<ISelectableImageMoverService>(this);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<ISelectableImageMoverService>();
    }

    public void SetImage(Transform objectToSet)
    {
        var width = canvasForRandomPosition.rect.width;
        var height = canvasForRandomPosition.rect.height;
        width = Random.Range(-width / 2, width / 2);
        height = Random.Range(-height / 2, height / 2);
        var randomPosition = new Vector2(width, height);
        objectToSet.transform.SetParent(movementParent);
        objectToSet.transform.localPosition = randomPosition;
    }
}
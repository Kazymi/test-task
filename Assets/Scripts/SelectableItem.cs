using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SelectableItem : MonoBehaviour
{
    [SerializeField] private SelectableItemUI selectableItemUi;

    private void OnClick()
    {
        var rectTransform = GetComponent<RectTransform>();
        selectableItemUi.SetButtonInteractable(false);
        var sequence = DOTween.Sequence();
        sequence.Append(selectableItemUi.ImageTransform.transform.DOScale(Vector3.zero, 0.4f));
        sequence.Join(selectableItemUi.DesciptionTransform.transform.DOScale(Vector3.zero, 0.4f));
        sequence.Append(rectTransform.DOSizeDelta(Vector3.zero, 0.4f).OnComplete(() =>
        {
            ServiceLocator.GetService<ISelectableImageMoverService>()
                .SetImage(selectableItemUi.ImageTransform.transform);
        }));
        sequence.Append(selectableItemUi.ImageTransform.transform.DOScale(Vector3.one, 0.4f));
        sequence.OnComplete(() => { Destroy(gameObject); });
    }

    public void Initialize()
    {
        var storageService = ServiceLocator.GetService<ISelectableItemStorageService>();
        var configuration = storageService.GetRandomSelectableItemConfiguration();
        selectableItemUi.SetButtonEvent(OnClick);
        selectableItemUi.SetImageAndDescription(configuration.Sprite, configuration.Description);
    }
}
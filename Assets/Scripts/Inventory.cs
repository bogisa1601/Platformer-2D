using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [field: SerializeField] public GameObject InventoryItemPrefab { get; private set; }

    [field : SerializeField] public int InventoryNumberOfItems { get; private set; }

    [field : SerializeField] public RectTransform InventoryFrame { get; private set; }
    [field: SerializeField] public RectTransform ContentRect { get; private set; }

    [field: SerializeField] public Button OpenInventoryButton { get; private set; }

    [field: SerializeField] public float InventoryAnimationDuration { get; private set; }



    private float _defaultAnchoredPositionX = 0;
    private float _openAnchoredPositionX = 0;
    private void Start()
    {
        _openAnchoredPositionX = -325f;
        _defaultAnchoredPositionX = InventoryFrame.anchoredPosition.x;

        for(int i = 0; i < InventoryNumberOfItems; i++)
        {
            Instantiate(InventoryItemPrefab, ContentRect);
        }
    }
    public void OnClickInventoryButton()
    {
        OpenInventoryButton.interactable = false;

        if (Mathf.Abs(InventoryFrame.anchoredPosition.x - _openAnchoredPositionX) < 1)
        {
            InventoryFrame.DOAnchorPosX(_defaultAnchoredPositionX, InventoryAnimationDuration).SetEase(Ease.InBack).OnComplete(() => { OpenInventoryButton.interactable = true; });
            return;
        }
        InventoryFrame.DOAnchorPosX(_openAnchoredPositionX, InventoryAnimationDuration).SetEase(Ease.InBack).OnComplete(() => { OpenInventoryButton.interactable = true; });
    }

    
}

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

    [field: SerializeField] public List<InventorySlot> InventorySlots { get; set; }
    
    [field: SerializeField] public InventorySlot MousePickedUpSlot { get; set; }
    [field: SerializeField] public InventorySlot MouseHoveredSlot { get; set; }
    [field: SerializeField] public Image DragNDropIconImageHolder { get; set; }





    private float _defaultAnchoredPositionX = 0;
    private float _openAnchoredPositionX = 0;

    private void OnEnable()
    {
        GameplayEvents.OnAddCollectable += HandleOnAddCollectable;
    }

    private void OnDisable()
    {
        GameplayEvents.OnAddCollectable -= HandleOnAddCollectable;

    }

    public void HandleOnAddCollectable(BaseCollectable baseCollectable)
    {
        AddItemToSlots(baseCollectable);
    }
    private void Start()
    {
        _openAnchoredPositionX = -325f;
        _defaultAnchoredPositionX = InventoryFrame.anchoredPosition.x;

        for(int i = 0; i < InventoryNumberOfItems; i++)
        {
            var gob = Instantiate(InventoryItemPrefab, ContentRect);
            var inventoryItem = gob.GetComponent<InventorySlot>();

            inventoryItem.SlotID = i;
            
            inventoryItem.Inventory = this;


            InventorySlots.Add(inventoryItem);
        }
    }

    public void AddItemToSlots(BaseCollectable baseCollectable)
    {
        for(int i = 0; i < InventorySlots.Count; i++)
        {
            if (InventorySlots[i].Collectable != null) continue;

            InventorySlots[i].Collectable = baseCollectable;

            InventorySlots[i].IconImage.sprite = baseCollectable.IconItemSprite;

            InventorySlots[i].IconImage.enabled = true;
            return;
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

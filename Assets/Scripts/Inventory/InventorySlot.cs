using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    [SerializeField] private ItemInfoUI _itemInfoUI;

    private ItemData _itemData;


    public void SetItem(ItemData item)
    {
        _itemData = item;
        _icon.sprite = item.icon;
    }



    public void ClearSlot()
    {
        _icon.sprite = null;
        _itemData = null;
    }


    public void OnClickSlot()
    {
        if (_itemData != null)
        {
            RectTransform slotRect = GetComponent<RectTransform>();

            _itemInfoUI.OpenMenu(_itemData, slotRect);
        }
    }


    public void SetItemInfoUI(ItemInfoUI itemInfoUI)
    {
        _itemInfoUI = itemInfoUI;
    }

}

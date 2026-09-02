using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSlot : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;

    [SerializeField] private Inventory _inventory;

    private ItemData _itemData;

    public ItemData ItemData
    {
        get { return _itemData; }
    }



    public void SetItem(ItemData item)
    {
        _itemData = item;
        _itemIcon.sprite = item.icon;
    }

    public bool IsEmpty
    {
        get { return _itemData == null; }
    }


    public ItemData RemoveItem()
    {
        ItemData item = _itemData;

        _itemData = null;
        _itemIcon.sprite = null;

        return item;
    }


    public void ReturnItem()
    {
        if (_itemData == null)
        {
            return;
        }

        _inventory.AddItem(_itemData);
        RemoveItem();
    }

}

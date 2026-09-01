using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemData> _items = new List<ItemData>();
    [SerializeField] private int _maxCount = 60;

    [Header("")]
    [SerializeField] private InventoryUI _inventoryUI;


    public List<ItemData> Items
    {
        get { return _items; }
    }


    public bool AddItem(ItemData item)
    {
        if(_items.Count >= _maxCount)
        {
            return false;
        }

        _items.Add(item);
        _inventoryUI.RefreshInventory();

        return true;
    }

    public void RemoveItem(ItemData item)
    {
        _items.Remove(item);
    }



}

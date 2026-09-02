using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventorySlot _slotPrefab;
    [SerializeField] private Transform _itemContent;
    [SerializeField] private ItemInfoUI _itemInfoUI;
    [SerializeField] private ScrollRect _scrollRect;

    [SerializeField] private GameObject _craftPanel;



    private List<InventorySlot> _slots = new List<InventorySlot>();


    private void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            InventorySlot slot = Instantiate(_slotPrefab, _itemContent);
            _slots.Add(slot);

            slot.SetItemInfoUI(_itemInfoUI);
        }

        _inventoryPanel.SetActive(false);
        _craftPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);

            if (_inventoryPanel.activeSelf)
            {
                RefreshInventory();
                _scrollRect.verticalNormalizedPosition = 1f;
            }
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {

            _craftPanel.SetActive(!_craftPanel.activeSelf);


        }

    }




    public void RefreshInventory()
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].ClearSlot();
        }


        for (int i = 0; i < _inventory.Items.Count; i ++)
        {
            _slots[i].SetItem(_inventory.Items[i]);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;

    [Header("버튼패널위치")]
    [SerializeField] private RectTransform _itemButtonPanelRect;

    [Header("버튼,아이템설명 패널")]
    [SerializeField] private GameObject _itemButtonPanel;
    [SerializeField] private GameObject _itemDetailPanel;

    [Header("플레이어 스탯들")]
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMana _playerMana;
    [SerializeField] private Sword _sword;
    [SerializeField] private PlayerMove _playerMove;


    [Header("인벤토리")]
    [SerializeField] private Inventory _inventory;

    [Header("인벤토리UI")]
    [SerializeField] private InventoryUI _inventoryUI;

    [Header("제작 슬롯")]
    [SerializeField] private CraftSlot[] _craftSlots;

    [Header("제작패널")]
    [SerializeField] private GameObject _craftPanel;



    private ItemData _selectedItem;


    private void Start()
    {
        _itemButtonPanel.SetActive(false);
        _itemDetailPanel.SetActive(false);

    }

    //public void SetItemInfo(ItemData item)
    //{
    //    Debug.Log("정보창 호출됨");

    //    _itemName.text = item.itemName;
    //    _itemDescription.text = item.description;
    //}


    public void OpenMenu(ItemData item, RectTransform slotRect)
    {
        _selectedItem = item;

        _itemButtonPanel.SetActive(true);
        _itemDetailPanel.SetActive(false);

        _itemButtonPanelRect.position = slotRect.position + new Vector3(-40f, -30f, 0f);
    }


    public void ShowInfo()
    {
        _itemButtonPanel.SetActive(false);
        _itemDetailPanel.SetActive(true);

        _itemName.text = _selectedItem.itemName;
        _itemDescription.text = _selectedItem.description;
    }



    public void CloseDetail()
    {
        _itemDetailPanel.SetActive(false);
    }


    public void UseItem()
    {
        if(_selectedItem == null)
        {
            return;
        }

        _playerAttack.AddDamage(_selectedItem.attackUp);
        _playerHealth.AddMaxHp(_selectedItem.healthUp);
        _playerMana.AddMaxMana(_selectedItem.manaUp);
        _playerMana.AddManaRegen(_selectedItem.manaRegenUp);
        _sword.DecreaseAttackDelay(_selectedItem.attackDelayDecrease);
        _playerMove.AddMoveSpeed(_selectedItem.moveSpeedUp);
        _playerHealth.AddHealthRegen(_selectedItem.healthRegenUp);
        _playerHealth.AddHealthRegenTime(_selectedItem.healthRegenTimer);
        _inventory.RemoveItem(_selectedItem);


        _selectedItem = null;
        _itemButtonPanel.SetActive(false);

        _inventoryUI.RefreshInventory();
    }


    public void EraseItem()
    {
        if (_selectedItem == null)
        {
            return;
        }

        _inventory.RemoveItem(_selectedItem);

        _selectedItem = null;
        _itemButtonPanel.SetActive(false);
        _itemDetailPanel.SetActive(false);

        _inventoryUI.RefreshInventory();
    }




    public void CloseButtonPanel()
    {
        _itemButtonPanel.SetActive(false);
    }


    public void AddCraftItem()
    {
        if (_selectedItem == null)
        {
            return;
        }

        for (int i = 0; i < _craftSlots.Length; i++)
        {
            if (_craftSlots[i].IsEmpty)
            {
                _craftSlots[i].SetItem(_selectedItem);
                _inventory.RemoveItem(_selectedItem);
                _inventoryUI.RefreshInventory();
                break;
            }
        }

        _itemButtonPanel.SetActive(false);
        _craftPanel.SetActive(true);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;


    public void SetItemInfo(ItemData item)
    {
        Debug.Log("정보창 호출됨");

        _itemName.text = item.itemName;
        _itemDescription.text = item.description;
    }


}

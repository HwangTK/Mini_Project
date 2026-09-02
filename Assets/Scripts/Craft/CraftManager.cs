using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private CraftSlot[] _craftSlots;



    public void Craft()
    {
        for (int i = 0; i < _craftSlots.Length; i++)
        {
            if (!_craftSlots[i].IsEmpty)
            {
                Debug.Log(_craftSlots[i].ItemData.itemName);
            }
        }
    }



}

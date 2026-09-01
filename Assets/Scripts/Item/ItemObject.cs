using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if(inventory != null )
            {
                bool isAdded = inventory.AddItem(_itemData);

                if (isAdded)
                {
                    Destroy(gameObject);
                }
            }
            Debug.Log(_itemData.itemName);
        }
    }



}

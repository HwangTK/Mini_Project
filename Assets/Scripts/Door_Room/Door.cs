using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _targetEntryPoint;
    [SerializeField] private CombatRoom _targetCombatRoom;
    [SerializeField] private ItemRoom _targetItemRoom;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = _targetEntryPoint.position;

            if (_targetCombatRoom != null)
            {
                _targetCombatRoom.StartBattle();
            }

            if (_targetItemRoom != null)
            {
                _targetItemRoom.SpawnItem();
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : MonoBehaviour
{

    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private GameObject[] _doors;

    private bool _isClear = false;


    void Start()
    {
        for (int i = 0; i < _doors.Length; i++)
        {
            _doors[i].SetActive(false);
        }
    }



    void Update()
    {
        if (!_isClear && IsAllMonstersDead())
        {
            _isClear = true;

            Debug.Log("¸ó½ºÅÍ Àü¸ê");
        }
    }

    private bool IsAllMonstersDead()
    {
        if (_monsters.Length == 0)
        {
            return false;
        }


        for (int i = 0; i < _monsters.Length; i++)
        {
            if (_monsters[i] != null)
            {
                return false;
            }
        }

        return true;
    }


}

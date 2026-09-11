using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : MonoBehaviour
{

    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private GameObject[] _doors;

    [Header("몬스터 최상위 오브젝트")]
    [SerializeField] private GameObject _monstersParent;

    private bool _isClear = false;


    void Start()
    {
        _monstersParent.SetActive(false);

        for (int i = 0; i < _doors.Length; i++)
        {
            _doors[i].SetActive(false);
        }
    }



    void Update()
    {
        DoorOpenClose();
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


    private void DoorOpenClose()
    {
        if (!_isClear && IsAllMonstersDead())
        {
            _isClear = true;

            Debug.Log("몬스터 전멸");


            for (int i = 0; i < _doors.Length; i++)
            {
                _doors[i].SetActive(true);
            }
        }
    }


    public void StartBattle()
    {
        _monstersParent.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("플레이어 체력")]
    [SerializeField] private float _playerHP;




    public void PlayerHit(float damage)
    {
        Debug.Log("플레이어 맞음");
        _playerHP -= damage;


        if( _playerHP <= 0)
        {
            _playerHP = 0;
            Debug.Log("플레이어사망");
        }
    }

}

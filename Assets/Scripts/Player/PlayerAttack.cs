using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private WeaponBase _currentWeapon;
    [SerializeField] private PlayerMove _playerMove;

    [SerializeField] private int _damage = 50;

    public int Damage
    {
        get { return _damage; }
    }



    void Update()
    {
        Attack();
    }


    private void Attack()
    {
        if (_playerMove.IsRolling)
        {
            return;
        }



        if(Input.GetMouseButton(0))
        {
           

            _currentWeapon.Attack();
            
                
        }
    }

    public void AddDamage(int damage)
    {
        _damage += damage;
        Debug.Log("현재 공격력 : " + _damage);
    }



}

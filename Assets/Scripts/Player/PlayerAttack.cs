using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private WeaponBase _currentWeapon;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Animator _animator;

    [SerializeField] private Sword _sword;
    [SerializeField] private Gun _gun;

    [SerializeField] private int _damage = 50;
    [SerializeField] private float _attackSpeed = 1f;


    public int Damage
    {
        get { return _damage; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
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


    public void AddAttackSpeed(float amount)
    {
        _attackSpeed += amount;
        Debug.Log("현재 공격속도 : " + _attackSpeed);
    }


    public void ChangeWeapon(WeaponBase weapon)
    {
        _currentWeapon = weapon;

        if (weapon == _gun)
        {
            _animator.SetInteger("Weapon", 1);
        }

        else if (weapon == _sword)
        {
            _animator.SetInteger("Weapon", 0);
        }
    }



}

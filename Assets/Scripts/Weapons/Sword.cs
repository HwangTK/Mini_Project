using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    [Header("검기 프리팹")]
    [SerializeField] private GameObject _slash;

    [Header("애니메이터")]
    [SerializeField] private Animator _animator;

    [Header("발사지점")]
    [SerializeField] private Transform _firePoint;


    [SerializeField] private float _attackSpeedMultiplier = 0.7f;
    [SerializeField] private float _damageMultiplier = 1.5f;

    [SerializeField] private PlayerMove _playerMove;

    [SerializeField] private PlayerAttack _playerAttack;


    private float _attackTimer;


    private void Update()
    {
        if(_attackTimer > 0f)
        {
            _attackTimer -= Time.deltaTime;
        }
    }


    public override void Attack()
    {
        if(_attackTimer > 0f)
        {
            return;
        }

        float finalAttackSpeed = _playerAttack.AttackSpeed * _attackSpeedMultiplier;
        float finalAttackDelay = 1f / finalAttackSpeed;

        _attackTimer = finalAttackDelay;

        if (_playerMove.IsMoving)
        {
            _animator.SetTrigger("SwordUpper");
        }
        else
        {
            _animator.SetTrigger("SwordFull");
        }




        Quaternion slashRot = _firePoint.rotation * Quaternion.Euler(0f, 90f, 0f);

        GameObject slash = Instantiate(_slash, _firePoint.position, slashRot);

        SwordShoot swordshoot = slash.GetComponent<SwordShoot>();

        swordshoot.SetDirection(_firePoint.forward);

        int finalDamage = Mathf.RoundToInt(_playerAttack.Damage * _damageMultiplier);

        swordshoot.SetDamage(finalDamage);


    }


}

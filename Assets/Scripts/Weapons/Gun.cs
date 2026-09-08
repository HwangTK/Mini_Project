using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    [Header("총알 프리팹")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("발사 지점")]
    [SerializeField] private Transform _firePoint;

    [Header("플레이어 스크립트")]
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerMove _playerMove;

    [Header("플레이어 애니메이터")]
    [SerializeField] private Animator _animator;

    [SerializeField] private float _attackSpeedMultiplier = 5f;
    [SerializeField] private float _damageMultiplier = 0.5f;

    private float _attackTimer;


    private void Update()
    {
        if (_attackTimer > 0f)
        {
            _attackTimer -= Time.deltaTime;
        }
    }


    public override void Attack()
    {
        if (_attackTimer > 0f)
        {
            return;
        }

        float finalAttackSpeed = _playerAttack.AttackSpeed * _attackSpeedMultiplier;
        float finalAttackDelay = 1f / finalAttackSpeed;

        _attackTimer = finalAttackDelay;

        if (_playerMove.IsMoving)
        {
            _animator.SetTrigger("GunShot");
        }
        else
        {
            _animator.SetTrigger("GunFull");
        }

        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

        BulletShoot bulletShoot = bullet.GetComponent<BulletShoot>();

        int finalDamage = Mathf.RoundToInt(_playerAttack.Damage * _damageMultiplier);

        bulletShoot.SetDamage(finalDamage);
    }
}

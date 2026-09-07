using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBase
{
    [Header("ÃÑ¾Ë ÇÁ¸®ÆÕ")]
    [SerializeField] private GameObject _bulletPrefab;

    [Header("¹ß»ç ÁöÁ¡")]
    [SerializeField] private Transform _firePoint;

    [SerializeField] private PlayerAttack _playerAttack;

    [SerializeField] private float _attackDelay = 0.2f;

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

        _attackTimer = _attackDelay;


        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

        BulletShoot bulletShoot = bullet.GetComponent<BulletShoot>();

        bulletShoot.SetDamage(_playerAttack.Damage);
    }
}

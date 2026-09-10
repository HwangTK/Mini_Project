using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [Header("총구")]
    [SerializeField] private Transform[] _firePoints;

    [Header("플레이어")]
    [SerializeField] private Transform _player;

    [SerializeField] private float _attackDelay = 2f;

    private float _attackTimer;

    private void Start()
    {
        _attackTimer = 3f;
    }

    void Update()
    {
        LookPlayer();

        _attackTimer -= Time.deltaTime;

        if (_attackTimer <= 0f)
        {
            Shoot();
            _attackTimer = _attackDelay;
        }
    }


    private void LookPlayer()
    {
        Vector3 targetDir = _player.position - transform.position;

        targetDir.y = 0f;

        if (targetDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetDir);
        }
    }


    private void Shoot()
    {
        for (int i = 0; i < _firePoints.Length; i++)
        {
            Instantiate(
                _bulletPrefab,
                _firePoints[i].position,
                _firePoints[i].rotation
            );
        }
    }
}
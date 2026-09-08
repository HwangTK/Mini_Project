using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{

    [SerializeField] private float _speed = 20f;

    private int _damage;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void SetDamage(int damage)
    {
        _damage = damage;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();

            if (monsterHealth != null)
            {
                monsterHealth.MonsterHit(_damage);
                Debug.Log(_damage);
            }

            Destroy(gameObject);
        }
    }
}

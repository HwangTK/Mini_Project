using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float _speed = 10f;
    private int _damage;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }


    private void Update()
    {
        transform.position += -transform.forward * _speed * Time.deltaTime;
    }


    public void SetDamage(int damage)
    {
        _damage = damage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("화염구 데미지 : " + _damage);

            MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();

            if (monsterHealth != null)
            {
                monsterHealth.MonsterHit(_damage);
            }

            Destroy(gameObject);
        }
    }


}

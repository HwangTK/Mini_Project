using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordShoot : MonoBehaviour
{
    [Header("투사체 속도")]
    [SerializeField] private float _speed = 10.0f;

   

    private float _destroy = 1.0f;
    private Vector3 _direction;


    void Start()
    {
        Destroy(gameObject, _destroy);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }


    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if (other.CompareTag("Monster"))
        {
            Debug.Log("피격");

            MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();

            if(monsterHealth != null )
            {
                monsterHealth.MonsterHit(50);
            }

            Destroy(gameObject);
        }
    }


}

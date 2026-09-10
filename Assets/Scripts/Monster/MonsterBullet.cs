using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _damage = 10;


    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.PlayerHit(_damage);
            }

            Destroy(gameObject);
        }
    }

}

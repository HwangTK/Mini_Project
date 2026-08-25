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
}

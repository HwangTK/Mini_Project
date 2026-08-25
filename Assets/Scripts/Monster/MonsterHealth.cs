using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [Header("∏ÛΩ∫≈Õ HP")]
    [SerializeField] private float _hp;


    public void MonsterHit(int damage)
    {
        _hp -= damage;

        if( _hp <= 0)
        {
            Destroy(gameObject);
        }


    }
}

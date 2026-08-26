using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonoBehaviour
{
    [SerializeField] private float _walkTime = 0f;

    [SerializeField] private LayerMask _wall;

    private float _speed = 1f;

    private float randomx;
    private float randomz;
    private Vector3 _dir;


    void Start()
    {
        
    }



    void Update()
    {
        MonsterMove();
    }



    private void MonsterMove()
    {
        _walkTime -= Time.deltaTime;

        if(_walkTime < 0.01f)
        {
            randomx = Random.Range(0.1f, 1f);
            randomz = Random.Range(0.1f, 1f);

            int signx = Random.Range(0, 2) == 0 ? 1 : -1;
            int signz = Random.Range(0, 2) == 0 ? 1 : -1;

            float dirx = signx * randomx;
            float dirz = signz * randomz;

            _dir = new Vector3(dirx, 0f, dirz).normalized;

           
            _walkTime = Random.Range(2f, 3f);


        }


        if(Physics.Raycast(transform.position, _dir, 2f, _wall))
        {
            _walkTime = 0f;
            return;
        }

        Quaternion _rot = Quaternion.LookRotation(_dir);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rot, 180f * Time.deltaTime);
        transform.position += _dir * _speed * Time.deltaTime;

    }





}

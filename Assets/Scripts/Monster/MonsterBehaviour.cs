using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private float _walkTime = 0f;

    [Header("플레이어")]
    [SerializeField] private Transform _player;

    [SerializeField] private LayerMask _wall;


    [Header("애니메이터")]
    [SerializeField] private Animator _animator;


    private float _speed = 1f;

    private float randomx;
    private float randomz;
    private Vector3 _dir;

    private bool _isAttack = false;

    public enum MonsterState
    {
        Walk,
        Chase,
        Attack
    }

    private MonsterState _state = MonsterState.Walk;



    void Start()
    {
        
    }



    void Update()
    {
        if (!_isAttack)
        {
            ChangeState();
        }

        switch (_state)
        {
            case MonsterState.Walk:
                MonsterMove();
                break;
            case MonsterState.Chase:
                MonsterChase();
                break;
            case MonsterState.Attack:
                MonsterAttack();
                break;
        }
    }

    private void ChangeState()
    {
        float distance = Vector3.Distance(transform.position, _player.position);

        if(distance < 2f)
        {
            _state = MonsterState.Attack;
        }
        else if(distance < 5f)
        {
            _state = MonsterState.Chase;
        }
        else
        {
            _state = MonsterState.Walk;
        }


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



    private void MonsterChase()
    {
        Vector3 targetDir = (_player.position - transform.position).normalized;
        Quaternion targetRot = Quaternion.LookRotation(targetDir);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 270f * Time.deltaTime);
        transform.position += targetDir * (_speed + 2f) * Time.deltaTime;


    }


    private void MonsterAttack()
    {
        if (_isAttack)
        {
            return;
        }

        _isAttack = true;

        _animator.SetTrigger("Attack");


    }


    private void AttackEnd()
    {
        _isAttack = false;
    }

}

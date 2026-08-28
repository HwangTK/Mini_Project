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


    [Header("공격 대미지")]
    [SerializeField] private int _damage = 10;

    [Header("공격 쿨타임")]
    [SerializeField] private float _attackCooldown = 3.0f;


    [Header("공격하는 주먹")]
    [SerializeField] private Transform _attackPoint;

    private float _attackTimer = 0f;



    private float _speed = 1f;

    private float randomx;
    private float randomz;
    private Vector3 _dir;

    private bool _isAttack = false;
    private bool _isHit = false;

    public bool IsAttacking
    {
        get { return _isAttack; }
    }




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
        if (_attackTimer > 0f)
        {
            _attackTimer -= Time.deltaTime;
        }
        else
        {
            _attackTimer = 0f;
            _animator.SetBool("isCoolDown", false);
        }

        if (_isHit)
        {
            return;
        }



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


        if (distance < 2f)
        {
            _animator.SetBool("isMove", false);
            _state = MonsterState.Attack;
        }
        else if(distance < 5f)
        {
            _animator.SetBool("isMove", true);
            _state = MonsterState.Chase;
        }
        else
        {
            _animator.SetBool("isMove", true);
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

        if(_attackTimer > 0f)
        {
            Vector3 targetDir = (_player.position - transform.position).normalized;
            Quaternion targetRot = Quaternion.LookRotation(targetDir);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 270f * Time.deltaTime);


            return;
        }


        _isAttack = true;

        _animator.SetTrigger("Attack");


    }


    public void AttackEnd()
    {
        _isAttack = false;
        _attackTimer = _attackCooldown;

        _animator.SetBool("isCoolDown", true);
    }



    public void AttackHit()
    {
        
        Vector3 bottom = _attackPoint.position + Vector3.up * 0.2f;
        Vector3 top = _attackPoint.position + Vector3.up * 0.4f;

        Collider[] hits = Physics.OverlapCapsule(bottom, top, 1.5f);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealth playerHealth = hit.GetComponent<PlayerHealth>();
                Debug.Log("쳐맞음");

                if (playerHealth != null)
                {
                    playerHealth.PlayerHit(_damage);
                }
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
        {
            return;
        }

        Vector3 attackPos = _attackPoint.position;

        Vector3 bottom = attackPos + Vector3.up * 0.2f;
        Vector3 top = attackPos + Vector3.up * 0.4f;

        Gizmos.DrawWireSphere(bottom, 0.5f);
        Gizmos.DrawWireSphere(top, 0.5f);
    }


    public void HitStart() 
    {
        _isHit = true;
    }


    public void HitEnd()
    {
        _isHit = false;
    }

}



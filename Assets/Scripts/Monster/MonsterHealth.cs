using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [Header("몬스터 HP")]
    [SerializeField] private float _hp;

    [Header("몬스터 렌더러")]
    [SerializeField] private Renderer _renderer;

    [Header("피격색상")]
    [SerializeField] private Color _hitColor = Color.red;

    [Header("깜빡거리는 시간")]
    [SerializeField] private float _hitTime = 0.2f;

    private Color _originColor;

    [SerializeField] private Animator _animator;
    [SerializeField] private MonsterBehaviour _monsterBehaviour;



    private void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _originColor = _renderer.material.color;

    }


    public void MonsterHit(int damage)
    {
        _hp -= damage;

        StartCoroutine(HitEffect());

        if (!_monsterBehaviour.IsAttacking)
        {
            _monsterBehaviour.HitStart();
            _animator.SetTrigger("Hit");
        }


        if ( _hp <= 0)
        {
            Destroy(gameObject);
        }


    }

    public IEnumerator HitEffect()
    {
        _renderer.material.color = _hitColor;

        yield return new WaitForSeconds(_hitTime);

        _renderer.material.color = _originColor;
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("스킬 투사체")]
    [SerializeField] private GameObject _skillOnePrefab;

    [Header("발사 지점")]
    [SerializeField] private Transform _firePoint;

    [Header("스킬데미지")]
    [SerializeField] private int _skillDamage = 1;


    [SerializeField] private PlayerMana _playerMana;
    [SerializeField] private int _skillOneMana = 20;


    private int _skillOne = 30;
    



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SkillOne();
        }
    }


    private void SkillOne()
    {
        if (!_playerMana.UseMana(_skillOneMana))
        {
            return;
        }

        int damage = _skillDamage * _skillOne;

        GameObject skill = Instantiate(_skillOnePrefab, _firePoint.position + _firePoint.up * 1f, _firePoint.rotation * Quaternion.Euler(0f, 180f, -90f));

        FireBall fireBall = skill.GetComponent<FireBall>();

        fireBall.SetDamage(damage);
    }


    public void AddSkillDamage(int damage)
    {
        _skillDamage += damage;
    }
}

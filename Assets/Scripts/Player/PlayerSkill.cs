using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("스킬 투사체")]
    [SerializeField] private GameObject _skillPrefab;

    [Header("발사 지점")]
    [SerializeField] private Transform _firePoint;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(_skillPrefab, _firePoint.position, _firePoint.rotation);
        }
    }




}

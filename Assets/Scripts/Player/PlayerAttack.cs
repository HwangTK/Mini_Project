using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private WeaponBase _currentWeapon;
    [SerializeField] private PlayerMove _playerMove;
    


    void Start()
    {
        
    }



    void Update()
    {
        Attack();
    }


    private void Attack()
    {
        if (_playerMove.IsRolling)
        {
            return;
        }



        if(Input.GetMouseButton(0))
        {
           

            _currentWeapon.Attack();
            
                
        }
    }


}

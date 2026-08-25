using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] WeaponBase _currentWeapon;

    


    void Start()
    {
        
    }



    void Update()
    {
        Attack();
    }


    private void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
           

            _currentWeapon.Attack();
            Debug.Log("АјАн");
                
        }
    }


}

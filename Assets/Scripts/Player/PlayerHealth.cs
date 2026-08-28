using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("플레이어 체력")]
    [SerializeField] private int _playerHP;

    [SerializeField] private Slider _hpSlider;

    [SerializeField] private TMP_Text _hpText;

    [SerializeField] private int _maxHp = 100;


    private void Start()
    {
        _playerHP = _maxHp;

        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _playerHP;

        _hpText.text = _playerHP + " / " + _maxHp;
    }


    public void PlayerHit(int damage)
    {
        Debug.Log("플레이어 맞음");
        _playerHP -= damage;
        

        if ( _playerHP <= 0)
        {
            _playerHP = 0;
            Debug.Log("플레이어사망");
        }

        _hpSlider.value = _playerHP;
        _hpText.text = _playerHP + " / " + _maxHp;

    }

}

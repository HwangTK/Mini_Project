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

    [SerializeField] private int _healthRegen = 5;
    [SerializeField] private float _regenTimer = 10f;

    private float _timer = 0f;




    private void Start()
    {
        _playerHP = _maxHp;

        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _playerHP;

        _hpText.text = _playerHP + " / " + _maxHp;
    }

    private void Update()
    {
        HealthRegen();
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

    public void AddMaxHp(int amount)
    {
        _maxHp += amount;
        _playerHP += amount;

        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _playerHP;
        _hpText.text = _playerHP + " / " + _maxHp;
    }


    private void HealthRegen()
    {
        if (_playerHP < _maxHp)
        {
            _timer += Time.deltaTime;

            if (_timer >= _regenTimer)
            {
                _playerHP += _healthRegen;
                _timer = 0f;

                if (_playerHP >= _maxHp)
                {
                    _playerHP = _maxHp;
                }

                _hpSlider.value = _playerHP;
                _hpText.text = _playerHP + " / " + _maxHp;
            }
        }
    }


    public void AddHealthRegen(int amount)
    {
        _healthRegen += amount;
    }

    public void AddHealthRegenTime(float amount)
    {
        _regenTimer -= amount;
    }
}

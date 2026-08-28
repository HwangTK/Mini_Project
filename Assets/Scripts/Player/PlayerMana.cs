using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] private int _playerMp;
    [SerializeField] private int _maxMp = 50;

    [SerializeField] private Slider _mpslider;
    [SerializeField] private TMP_Text _mpText;

    [SerializeField] private int _manaRegen = 1;
    [SerializeField] private float _regenTimer = 1f;

    private float _timer = 0;


    void Start()
    {
        _playerMp = _maxMp;

        _mpslider.maxValue = _maxMp;
        _mpslider.value = _playerMp;

        _mpText.text = _playerMp + " / " + _maxMp;

    }



    void Update()
    {
        ManaRegen();
    }



    public bool UseMana(int mana)
    {
        if (_playerMp < mana)
        {
            return false;
        }

        _playerMp -= mana;

        _mpslider.value = _playerMp;
        _mpText.text = _playerMp + " / " + _maxMp;


        return true;

    }


    private void ManaRegen()
    {
        if(_playerMp < _maxMp)
        {
            _timer += Time.deltaTime;

            if (_timer >= _regenTimer)
            {
                _playerMp += _manaRegen;
                _timer = 0f;

                if (_playerMp >= _maxMp)
                {
                    _playerMp = _maxMp;
                }

                _mpslider.value = _playerMp;
                _mpText.text = _playerMp + " / " + _maxMp;

            }




        }
    }


}

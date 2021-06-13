using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int _hp = 10;
    private int _maxHP;

    public Image healthBar;

    private void Start()
    {
        _maxHP = _hp;
        healthBar.fillAmount = _maxHP / _hp;
    }

    public void TakeDamage(int damage)
    {
        if (_hp - damage < 0)
        {
            _hp = 0;
            Debug.Log("Game over handler here!");
            healthBar.fillAmount = 0;
            return;
        }

        _hp -= damage;
        healthBar.fillAmount = (float)_hp / _maxHP;
    }
}

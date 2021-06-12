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
            _hp = 0;
        else
            _hp -= damage;

        if (_hp > 0)
            healthBar.fillAmount = (float)_hp / _maxHP;
        else
            healthBar.fillAmount = 0;

        Debug.Log("percentage: " + (float)_hp / _maxHP);
        if (_hp <= 0f)
            Debug.Log("Game over handler here!");
    }
}

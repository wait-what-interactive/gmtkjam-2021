using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int _hp = 10;
    private int _maxHP;
    private bool isDead = false;

    public Image healthBar;

    private void Start()
    {
        isDead = false;
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
            isDead = true;
            return;
        }

        _hp -= damage;
        healthBar.fillAmount = (float)_hp / _maxHP;
    }

    public bool IsDead()
    {
        return isDead;
    }    
}

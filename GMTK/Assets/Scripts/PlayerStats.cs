using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int _hp = 10;
    private int _maxHP;

    private MainMenuManager mainMenuManager;
    private Image healthBar;

    private void Start()
    {
        mainMenuManager = GameObject.FindGameObjectWithTag("buttons_manager").GetComponent<MainMenuManager>();
        healthBar = GameObject.FindGameObjectWithTag("hp").GetComponent<Image>();

        _maxHP = _hp;
        healthBar.fillAmount = _maxHP / _hp;
    }

    public void TakeDamage(int damage)
    {
        if (_hp - damage <= 0)
        {
            _hp = 0;
            healthBar.fillAmount = 0;
            mainMenuManager.Lose();
            return;
        }

        _hp -= damage;
        healthBar.fillAmount = (float)_hp / _maxHP;
    }

    public float GetHP()
    {
        return _hp;
    }

}

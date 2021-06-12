using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _hp = 10;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if(_hp <= 0f)
            Debug.Log("Game over handler here!");
    }
}

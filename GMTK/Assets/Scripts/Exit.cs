using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public PlayerStats _playerStats;
    private ParticleSystem ps;

    private void Start() {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            _playerStats.TakeDamage(enemy.GetDamage());
            Destroy(other.gameObject);
            LevelManager.enemyCount -= 1;
            ps.Play();
        }
    }
}

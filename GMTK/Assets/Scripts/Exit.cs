using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public PlayerStats _playerStats;
    private MainMenuManager mainMenuManager;
    private ParticleSystem ps;

    private void Start() 
    {
        ps = GetComponentInChildren<ParticleSystem>();
        mainMenuManager = GameObject.FindGameObjectWithTag("buttons_manager").GetComponent<MainMenuManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SoundManager.instance?.BaseHurtPlay();
            Enemy enemy = other.GetComponent<Enemy>();
            _playerStats.TakeDamage(enemy.GetDamage());
            Destroy(other.gameObject);
            LevelManager.enemyCount -= 1;
            Win();
            ps.Play();
        }
    }

    public void Win()
    {
        if (_playerStats.GetHP() > 0 && LevelManager.enemyCount == 0)
        {
            mainMenuManager.Win();
            print("you win");
        }
    }
}

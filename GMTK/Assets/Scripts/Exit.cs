using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public PlayerStats _playerStats;
    private MainMenuManager mainMenuManager;
    private ParticleSystem ps;
    private LevelManager levelManager;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        mainMenuManager = GameObject.FindGameObjectWithTag("buttons_manager").GetComponent<MainMenuManager>();
        levelManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SoundManager.instance?.BaseHurtPlay();
            Enemy enemy = other.GetComponent<Enemy>();
            _playerStats.TakeDamage(enemy.GetDamage());
            Destroy(other.gameObject);
            levelManager.DecreaseEnemies();
            Win();
            ps.Play();
        }
    }

    public void Win()
    {
        if (_playerStats.GetHP() > 0 && levelManager.GetEnemyCount() == 0)
        {
            mainMenuManager.Win();
            print("you win");
        }
    }
}

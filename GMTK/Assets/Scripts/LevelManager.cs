using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyClass
{
    public int count;
    public GameObject prefab;
    public Color color;
    public float enemySpeed = 5f;
    public float enemyHP = 100f;
    public int damage = 1;

    public float delayBetweenSpawn = 0.2f;
}

[System.Serializable]
public class Wave
{
    public List<EnemyClass> enemies = new List<EnemyClass>();
    public float timeToNext = 60f;
}
public class LevelManager : MonoBehaviour
{
    public List<Wave> waves = new List<Wave>();
    private int currentWave = 0;
    private float _timer;
    public Transform startPoint;
    public List<Transform> levelPath;
    void Start()
    {
        _timer = waves[currentWave]?.timeToNext ?? 60f;
        StartCoroutine(MakeWave());
    }

    void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            if (waves.Count != currentWave)
            {
                _timer = waves[currentWave]?.timeToNext ?? 60f;
                StartCoroutine(MakeWave());
            }
        }
    }

    private IEnumerator MakeWave()
    {
        Wave wave = waves[currentWave];

        List<EnemyClass> enemies = waves[currentWave].enemies;

        foreach (var enemy in enemies)
        {
            for (int i = 0; i < enemy.count; i++)
            {
                Enemy spawned = Instantiate(enemy.prefab, startPoint.position, Quaternion.identity).GetComponent<Enemy>();
                spawned.SetLevelPath(levelPath);
                spawned.SetStats(enemy.damage, enemy.enemySpeed, enemy.enemyHP);
                yield return new WaitForSeconds(enemy.delayBetweenSpawn);
            }
        }
        currentWave++;
    }

}

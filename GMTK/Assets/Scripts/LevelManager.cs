using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float delayToNextEnemyGroup = 1f;
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

    private int enemyCount = 0;
    private ParticleSystem portalParticles;
    private Image waveImage;
    private Text waveCountText;
    private float currentWaveTick = 0f;
    private Exit exit;
    private int currentEnemies = 0;

    void Start()
    {
        GameObject waveContainer = GameObject.FindGameObjectWithTag("WaveContainer");
        waveImage = GameObject.FindGameObjectWithTag("WaveIndicator").GetComponent<Image>();
        waveCountText = waveContainer.GetComponentInChildren<Text>();
        exit = GameObject.FindGameObjectWithTag("exit").GetComponent<Exit>();

        if (!SoundManager.instance.GameMusicPlaying())
            SoundManager.instance.GameMusicPlay();

        portalParticles = startPoint.GetComponentInChildren<ParticleSystem>();
        _timer = waves[currentWave]?.timeToNext ?? 60f;
        for (int i = 0; i < waves.Count; ++i)
        {
            for (int j = 0; j < waves[i].enemies.Count; ++j)
                enemyCount += waves[i].enemies[j].count;
        }

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
        waveCountText.text = $"{currentWave + 1} / {waves.Count}";

        Wave wave = waves[currentWave];
        List<EnemyClass> enemies = waves[currentWave].enemies;

        foreach (var enemy in enemies)
        {
            portalParticles.Play();
            yield return new WaitForSeconds(0.3f);
            waveImage.fillAmount = 1f;
            currentEnemies += enemy.count;
            currentWaveTick = 1f / currentEnemies;
            for (int i = 0; i < enemy.count; i++)
            {
                SoundManager.instance?.EnemySpawnPlay();
                Enemy spawned = Instantiate(enemy.prefab, startPoint.position, Quaternion.identity).GetComponent<Enemy>();
                spawned.SetLevelPath(levelPath);
                spawned.SetStats(enemy.damage, enemy.enemySpeed, enemy.enemyHP);
                yield return new WaitForSeconds(enemy.delayBetweenSpawn);
            }

            portalParticles.Stop();
            yield return new WaitForSeconds(enemy.delayToNextEnemyGroup);
        }
        currentWave++;
    }

    public void DecreaseEnemies()
    {
        if (enemyCount > 0)
        {
            enemyCount -= 1;
            currentEnemies -= 1;
            waveImage.fillAmount = waveImage.fillAmount - currentWaveTick;
            Debug.Log(currentEnemies);
            Debug.Log(currentWaveTick);
        }

        if (enemyCount <= 0)
            exit.Win();
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }
}

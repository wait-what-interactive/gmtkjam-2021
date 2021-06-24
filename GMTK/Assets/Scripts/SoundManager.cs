using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [Header("Music")]
    public AudioSource menuMusic;
    public AudioSource gameMusic;

    [Header("Sounds")]
    public AudioSource enemySpawn;
    public AudioSource towerBuild;
    public AudioSource towerDestroy;
    public AudioSource shoot;
    public AudioSource hoverButton;
    public AudioSource baseHurt;
    public AudioSource win;
    public AudioSource lose;
    public AudioSource noMoreTowers;

    private List<AudioSource> sfx = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
        AudioSource[] sfxSource =
        { baseHurt, hoverButton, shoot, towerDestroy, 
            towerBuild, enemySpawn, lose, win, noMoreTowers,
            gameMusic, menuMusic
        };
        sfx.AddRange(sfxSource);
    }

    private void Start()
    {
        //  play music 
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Menu")
        {
            //  play menu music
            menuMusic.Play();
        }
    }

    public bool GameMusicPlaying()
    {
        return gameMusic.isPlaying;
    }

    public void GameMusicPlay()
    {
        gameMusic.Play();
    }

    public void GameMusicStop()
    {
        gameMusic.Stop();
    }

    public void MenuMusicPlay()
    {
        menuMusic.Play();
    }

    public void MenuMusicStop()
    {
        menuMusic.Stop();
    }

    public void EnemySpawnPlay()
    {
        enemySpawn.Play();
    }
    public void TowerBuildPlay()
    {
        towerBuild.Play();
    }
    public void TowerDestroyPlay()
    {
        towerDestroy.Play();
    }
    public void ShootPlay()
    {
        shoot.Play();
    }
    public void HoverButtonPlay()
    {
        hoverButton.Play();
    }
    public void HoverButtonStop()
    {
        hoverButton.Stop();
    }
    public void BaseHurtPlay()
    {
        baseHurt.Play();
    }

    public void WinPlay()
    {
        Time.timeScale = 0;
        win.Play();
    }

    public void LosePlay()
    {
        Time.timeScale = 0;
        lose.Play();
    }

    public void NoMoreTowersPlay()
    {
        noMoreTowers.Play();
    }

    public void ChangeVolume(float value)
    {
        foreach (var sfxElement in sfx)
            sfxElement.volume = 1f - value;
    }
}

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
    }

    void Start()
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
}

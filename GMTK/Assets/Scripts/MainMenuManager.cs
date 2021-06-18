using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    bool isPaused = false;
    public GameObject loseText;
    public LevelManager levelManager;

    public void Play(string sceneName)
    {
        SoundManager.instance.MenuMusicStop();
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            return;
        }

        Time.timeScale = .0001f;
        isPaused = true;

    }

    public void Menu()
    {
        SoundManager.instance.GameMusicStop();
        SoundManager.instance.MenuMusicPlay();
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Lose()
    {
        Pause();
        loseText.SetActive(true);
    }

}

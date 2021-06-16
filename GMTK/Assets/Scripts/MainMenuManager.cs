using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    bool isPaused = false;
    public GameObject looseText;
    public PlayerStats playerStats;

    private void Start()
    {
        StartCoroutine(LooseChecker());
    }

    private IEnumerator LooseChecker()
    {
        while (true)
        {
            if (Loose())
                break;
            yield return .3f;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
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
        SceneManager.LoadScene("Menu");
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool Loose()
    {
        if (playerStats.IsDead())
        {
            Pause();
            looseText.SetActive(true);
            return true;
        }
        return false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    bool isPaused = false;
    public GameObject loseText;
    public GameObject winText;

    public Slider volume;

    private float min = 1f;
    private float max = 0f;

    private void Start()
    {
        if (volume)
        {
            volume.minValue = max;
            volume.maxValue = min;
            volume.value = PlayerPrefs.GetFloat("volume", max);
        }
    }

    private IEnumerator Delay(float delay, GameObject show)
    {
        yield return new WaitForSeconds(delay);
        Pause();
        show.SetActive(true);
    }

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
        StartCoroutine(Delay(1f, loseText));
    }

    public void Win()
    {
        StartCoroutine(Delay(1f, winText));
    }

    public void OnChangeSlider(Slider slider)
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        SoundManager.instance.ChangeVolume(slider.value);
    }
}

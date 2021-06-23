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
            volume.minValue = min;
            volume.maxValue = max;
            volume.value = PlayerPrefs.GetFloat("volume", max);
        }
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
        Pause();
        loseText.SetActive(true);
    }

    public void Win()
    {
        Pause();
        winText.SetActive(true);
    }

    public void OnChangeSlider(Slider slider){
        SoundManager.instance.ChangeVolume(slider.value);
    }
}

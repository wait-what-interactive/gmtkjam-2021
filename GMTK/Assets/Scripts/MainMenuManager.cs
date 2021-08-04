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
    public GameObject nextLevelText;
    public GameObject currLevelText;

    public Slider volume;

    private float min = 1f;
    private float max = 0f;
    private float _biuldIndexOffset = 3;
    private string _levelCounterDecorator = "level : ";

    private void Start()
    {
        Time.timeScale = 1;
        if (volume)
        {
            volume.minValue = max;
            volume.maxValue = min;
            volume.value = PlayerPrefs.GetFloat("volume", max);
        }

        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
            nextLevelText?.SetActive(false);
        else
            nextLevelText?.SetActive(true);

    }

    private IEnumerator Delay(float delay, GameObject show, System.Action func)
    {
        yield return new WaitForSeconds(delay);
        Pause();
        show.SetActive(true);
        func();
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

        Time.timeScale = 0f;
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
        StartCoroutine(Delay(1f, loseText, () => { SoundManager.instance?.LosePlay(); }));
    }

    public void Win()
    {
        StartCoroutine(Delay(1f, winText, () => { SoundManager.instance?.WinPlay(); }));
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnChangeSlider(Slider slider)
    {
        PlayerPrefs.SetFloat("volume", slider.value);
        SoundManager.instance.ChangeVolume(slider.value);
    }

    public void OnLevelChange()
    {
        var levelIndex = (SceneManager.GetActiveScene().buildIndex - _biuldIndexOffset).ToString();

        if (levelIndex == "0")
            levelIndex = "tutorial".ToString();

        currLevelText.GetComponent<Text>().text = _levelCounterDecorator + levelIndex;
    }
}

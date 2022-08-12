using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public GameObject panelMenu;
    public GameObject panelSetting;
    public GameObject panelExit;

    public Button startButton;
    public Button settingButton;
    public Button exitButton;

    public Button saveSettingButton;
    public Button cancelExitButton;
    public Button yesExitButton;

    public Slider audioSlider;
    public Toggle vibartionToggle;

    void Start()
    {
        ButtnReAction();
    }
    void ButtnReAction()
    {
        HighScore();
        startButton.onClick.AddListener(() => StartButton());
        settingButton.onClick.AddListener(() => SettingButton());
        saveSettingButton.onClick.AddListener(() => SaveSettingButton());
        exitButton.onClick.AddListener(() => ExitButton());
        cancelExitButton.onClick.AddListener(() => CancelExitButton());
        yesExitButton.onClick.AddListener(() => YesExitButton());

    }

    void HighScore()
    {
        //if (PlayerPrefs.HasKey("Score"))
        //{
        //    highScore.text = PlayerPrefs.GetInt("Score").ToString();
        //}

        if (PlayerPrefs.HasKey("Record"))
        {
            highScore.text = PlayerPrefs.GetInt("Record").ToString();
            Debug.LogWarning(PlayerPrefs.GetInt("Record"));
        }
    }

    void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    void SettingButton()
    {
        panelSetting.SetActive(true);
        panelMenu.SetActive(false);
    }

    void SaveSettingButton()
    {
        panelSetting.SetActive(false);
        panelMenu.SetActive(true);
    }

    void ExitButton()
    {
        panelExit.SetActive(true);
        panelMenu.SetActive(false);
    }

    void CancelExitButton()
    {
        panelExit.SetActive(false);
        panelMenu.SetActive(true);
    }

    void YesExitButton()
    {
        Application.Quit();
    }

    void AudioSlider()
    {

    }

    void VibartionToggle()
    {

    }
}

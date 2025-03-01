using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button startButton;  //  нопка старта игры
    public Button settingsButton; //  нопка настроек игры
    public Button exitButton; //  нопка выхода из игры

    public Button keyboardButton; //  нопка управлени€ клавиатурой
    public Button joystickButton; //  нопка управление джойстиком
    public Button gyroscopeButton; //  нопка управлени€ гироскопом

    public GameObject panel; // ѕанель с кнопками выбора управлени€

    void Start()
    {
        startButton.onClick.AddListener(() => StartGame());
        settingsButton.onClick.AddListener(() => SettingsOpen());
        exitButton.onClick.AddListener(() => Exit());
        keyboardButton.onClick.AddListener(() => SetControlMode("keyboard"));
        joystickButton.onClick.AddListener(() => SetControlMode("joystick"));
        gyroscopeButton.onClick.AddListener(() => SetControlMode("gyroscope"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsOpen()
    {
        panel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void SetControlMode(string mode)
    {
        GameSettings.ControlMode = mode;
        panel.SetActive(false);
    }
}

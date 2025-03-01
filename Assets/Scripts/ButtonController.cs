using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button startButton;  // ������ ������ ����
    public Button settingsButton; // ������ �������� ����
    public Button exitButton; // ������ ������ �� ����

    public Button keyboardButton; // ������ ���������� �����������
    public Button joystickButton; // ������ ���������� ����������
    public Button gyroscopeButton; // ������ ���������� ����������

    public GameObject panel; // ������ � �������� ������ ����������

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

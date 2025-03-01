using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static ButtonController Instance { get; private set; }

    public Button startButton;  // ������ ������ ����
    public Button settingsButton; // ������ �������� ����
    public Button exitButton; // ������ ������ �� ����

    public Button keyboardButton; // ������ ���������� �����������
    public Button joystickButton; // ������ ���������� ����������
    public Button gyroscopeButton; // ������ ���������� ����������

    public Button menuButton; // ������ �������� � ����

    public GameObject panel; // ������ � �������� ������ ����������

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateButtons();
    }

    void UpdateButtons()
    {
        startButton = GameObject.Find("StartButton")?.GetComponent<Button>();
        settingsButton = GameObject.Find("SettingsButton")?.GetComponent<Button>();
        exitButton = GameObject.Find("ExitButton")?.GetComponent<Button>();
        keyboardButton = GameObject.Find("KeyboardButton")?.GetComponent<Button>();
        joystickButton = GameObject.Find("JoystickButton")?.GetComponent<Button>();
        gyroscopeButton = GameObject.Find("GyroscopeButton")?.GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton")?.GetComponent<Button>();
        panel = GameObject.Find("SettingsPanel");

        startButton.onClick.AddListener(() => StartGame());
        settingsButton.onClick.AddListener(() => SettingsOpen());
        exitButton.onClick.AddListener(() => Exit());
        keyboardButton.onClick.AddListener(() => SetControlMode("keyboard"));
        joystickButton.onClick.AddListener(() => SetControlMode("joystick"));
        gyroscopeButton.onClick.AddListener(() => SetControlMode("gyroscope"));
        menuButton.onClick.AddListener(() => OpenMenu());
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

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    void SetControlMode(string mode)
    {
        GameSettings.ControlMode = mode;
        panel.SetActive(false);
    }
}
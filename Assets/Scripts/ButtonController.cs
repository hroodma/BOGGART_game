using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public static ButtonController Instance;

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

    private void Start()
    {
        panel.SetActive(false);
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

        if (startButton != null)
            startButton.onClick.AddListener(() => StartGame());

        if (settingsButton != null)
            settingsButton.onClick.AddListener(() => SettingsOpen());

        if (exitButton != null)
            exitButton.onClick.AddListener(() => Exit());

        if (keyboardButton != null)
            keyboardButton.onClick.AddListener(() => SetControlMode("keyboard"));

        if (joystickButton != null)
            joystickButton.onClick.AddListener(() => SetControlMode("joystick"));

        if (gyroscopeButton != null)
            gyroscopeButton.onClick.AddListener(() => SetControlMode("gyroscope"));

        if (menuButton != null)
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
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Player player; // Ссылка на класс Player

    private Rigidbody2D _rb; // Ссылка на Rigidbody2D
    private FixedJoystick _fixedJoystick;

    string controlMode; // Режим управления

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        controlMode = GameSettings.ControlMode;
        _fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    void Update()
    {
        switch (controlMode)
        {
            case "keyboard":
                player.MoveKeyboard(_rb);
                break;

            case "joystick":
                player.MoveJoystick(_rb, _fixedJoystick);
                break;

            case "gyroscope":
                Debug.Log("Игра запущена с управлением: гироскоп");
                // Настройка управления гироскопом
                break;

            default:
                Debug.Log("Режим управления не выбран, используется клавиатура");
                break;
        }
    }
}

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Player player; // —сылка на класс Player

    private Rigidbody2D _rb; // —сылка на Rigidbody2D
    private FixedJoystick _fixedJoystick; // —сылка на джойстик

    string controlMode; // –ежим управлени€

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        controlMode = GameSettings.ControlMode;
        _fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        _fixedJoystick.gameObject.SetActive(false);
    }

    void Update()
    {
        switch (controlMode)
        {
            case "keyboard":
                player.MoveKeyboard(_rb);
                break;

            case "joystick":
                _fixedJoystick.gameObject.SetActive(true);
                player.MoveJoystick(_rb, _fixedJoystick);
                break;

            case "gyroscope":
                player.MoveGyroscope(_rb);
                break;

            default:
                Debug.Log("–ежим управлени€ не выбран, используетс€ клавиатура");
                break;
        }
    }
}

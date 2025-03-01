using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Player player; // ������ �� ����� Player

    private Rigidbody2D _rb; // ������ �� Rigidbody2D
    private FixedJoystick _fixedJoystick;

    string controlMode; // ����� ����������

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
                Debug.Log("���� �������� � �����������: ��������");
                // ��������� ���������� ����������
                break;

            default:
                Debug.Log("����� ���������� �� ������, ������������ ����������");
                break;
        }
    }
}

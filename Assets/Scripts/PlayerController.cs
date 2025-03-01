using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player; // ������ �� ����� Player

    private Rigidbody2D rb; // ������ �� Rigidbody2D

    string controlMode;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controlMode = GameSettings.ControlMode;
    }

    void Update()
    {
        switch (controlMode)
        {
            case "keyboard":
                player.MoveKeyboard(rb);
                break;

            case "joystick":
                Debug.Log("���� �������� � �����������: ��������");
                // ��������� ���������� ����������
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

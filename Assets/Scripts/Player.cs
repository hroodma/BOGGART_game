using UnityEngine;

public class Player : MonoBehaviour
{

    int _hp; // �������� ������
    int _maxHp = 3; // ������������ �������� ������
    int _score; // ���� ������
    float _speed; // �������� ������
    float _maxSpeed = 4f; // ������������ �������� ������

    private void Start()
    {
        _speed = 2f;
    }

    // �������� ����� ��������� ����� �����
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        switch (tag)
        {
            case "Health":
                _hp++;
                break;
            case "Key":
                _score++;
                break;
            case "BoostSpeed":
                _speed += 2f;
                break;
            default:
                break;
        }
    }

    public void Move(Rigidbody2D rb)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]int _hp; // �������� ������
    int _maxHp; // ������������ �������� ������
    int _score; // ���� ������
    float _speed; // �������� ������
    float _maxSpeed; // ������������ �������� ������

    private void Start()
    {
        _maxHp = 3; // ��������� ������������� ��������
        _hp = _maxHp; // ��������� ��������
        _maxSpeed = 4f; // ��������� ������������ ��������
        _speed = _maxSpeed; // ��������� ��������
        _score = 0; // ��������� �����
    }

    // �������� ����� ��������� ����� �����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag; // �������� ��� �������, � ������� �����������
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

    // �������� ������
    public void Move(Rigidbody2D rb)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // ��������� �����
    public void TakeDamage(int damage)
    {
        if(_hp > damage)
        {
            _hp -= damage;
        }
        else
        {
            // ������������ ������
            SceneManager.LoadScene(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]int _hp; // �������� ������
    int _maxHp; // ������������ �������� ������
    [SerializeField]int _score; // ���� ������
    [SerializeField]float _speed; // �������� ������
    float _maxSpeed; // ������������ �������� ������
    float _minSpeed; // ����������� �������� ������

    private Text scoreText;
    private Text hpText;

    private void Start()
    {
        _maxHp = 3; // ��������� ������������� ��������
        _hp = _maxHp; // ��������� ��������
        _maxSpeed = 4f; // ��������� ������������ ��������
        _minSpeed = 2f; // ��������� ����������� ��������
        _speed = _minSpeed; // ��������� ��������
        _score = 0; // ��������� �����

        scoreText = GameObject.Find("CountScore").GetComponent<Text>();
        hpText = GameObject.Find("CountHp").GetComponent<Text>();

        scoreText.text = _score.ToString();
        hpText.text = $"x{_hp}";
    }

    // �������� ������ ��� ������ ����������
    public void MoveKeyboard(Rigidbody2D rb)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // �������� ������ ��� ������ ���������
    public void MoveJoystick(Rigidbody2D rb, FixedJoystick joystick)
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // �������� ������ ��� ������ ���������
    public void MoveGyroscope(Rigidbody2D rb)
    {
        float moveX = Input.acceleration.x;
        float moveY = Input.acceleration.y;

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // ��������� �����
    public void TakeDamage(int damage)
    {
        if(_hp > damage)
        {
            _hp -= damage;
            hpText.text = $"x{_hp}";
        }
        else
        {
            // ������������ ������
            SceneManager.LoadScene(1);
        }
    }

    // ��������� ������
    public void TakeBonus(string bonus, int point)
    {
        switch (bonus)
        {
            case "Health":
                if(_hp < _maxHp)
                {
                    _hp += point;
                    hpText.text = $"x{_hp}";
                }
                break;

            case "BoostSpeed":
                if (_speed == _minSpeed && _speed <= _maxSpeed)
                {
                    StartCoroutine(BoostSpeed(point));
                }
                break;

            case "Key":
                _score += point;
                scoreText.text = _score.ToString();
                break;
        }
    }

    IEnumerator BoostSpeed(int point)
    {
        _speed += point;
        yield return new WaitForSeconds(5f);
        _speed = _minSpeed;
    }
}

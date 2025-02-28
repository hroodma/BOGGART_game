using System.Collections;
using System.Drawing;
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

    private void Start()
    {
        _maxHp = 3; // ��������� ������������� ��������
        _hp = _maxHp; // ��������� ��������
        _maxSpeed = 4f; // ��������� ������������ ��������
        _minSpeed = 2f; // ��������� ����������� ��������
        _speed = _minSpeed; // ��������� ��������
        _score = 0; // ��������� �����
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

    // ��������� ������
    public void TakeBonus(string bonus, int point)
    {
        switch (bonus)
        {
            case "Health":
                if(_hp < _maxHp)
                {
                    _hp += point;
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

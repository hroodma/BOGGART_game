using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]int _hp; // Здоровье игрока
    int _maxHp; // Максимальное здоровье игрока
    [SerializeField]int _score; // Очки игрока
    [SerializeField]float _speed; // Скорость игрока
    float _maxSpeed; // Максимальная скорость игрока
    float _minSpeed; // Минимальная скорость игрока

    private Text scoreText;
    private Text hpText;

    private void Start()
    {
        _maxHp = 3; // Установка максимального здоровья
        _hp = _maxHp; // Установка здоровья
        _maxSpeed = 4f; // Установка максимальной скорости
        _minSpeed = 2f; // Установка минимальной скорости
        _speed = _minSpeed; // Установка скорости
        _score = 0; // Установка очков

        scoreText = GameObject.Find("CountScore").GetComponent<Text>();
        hpText = GameObject.Find("CountHp").GetComponent<Text>();

        scoreText.text = _score.ToString();
        hpText.text = $"x{_hp}";
    }

    // Движение игрока при помощи клавиатуры
    public void MoveKeyboard(Rigidbody2D rb)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // Движение игрока при помощи джойстика
    public void MoveJoystick(Rigidbody2D rb, FixedJoystick joystick)
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // Движение игрока при помощи гироскопа
    public void MoveGyroscope(Rigidbody2D rb)
    {
        float moveX = Input.acceleration.x;
        float moveY = Input.acceleration.y;

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // Получение урона
    public void TakeDamage(int damage)
    {
        if(_hp > damage)
        {
            _hp -= damage;
            hpText.text = $"x{_hp}";
        }
        else
        {
            // Перезагрузка уровня
            SceneManager.LoadScene(1);
        }
    }

    // Получение бонуса
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]int _hp; // Здоровье игрока
    int _maxHp; // Максимальное здоровье игрока
    [SerializeField]int _score; // Очки игрока
    float _speed; // Скорость игрока
    float _maxSpeed; // Максимальная скорость игрока
    float _minSpeed; // Минимальная скорость игрока

    private void Start()
    {
        _maxHp = 3; // Установка максимального здоровья
        _hp = _maxHp; // Установка здоровья
        _maxSpeed = 4f; // Установка максимальной скорости
        _speed = _maxSpeed; // Установка скорости
        _score = 0; // Установка очков
    }

    // Движение игрока
    public void Move(Rigidbody2D rb)
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * _speed;

        rb.linearVelocity = movement;
    }

    // Получение урона
    public void TakeDamage(int damage)
    {
        if(_hp > damage)
        {
            _hp -= damage;
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
                }
                break;
            case "BoostSpeed":
                if (_speed == _minSpeed)
                {
                    _speed += point;
                }
                break;
            case "Key":
                _score += point;
                break;
        }
    }
}

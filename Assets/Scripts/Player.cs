using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]int _hp; // Здоровье игрока
    int _maxHp; // Максимальное здоровье игрока
    int _score; // Очки игрока
    float _speed; // Скорость игрока
    float _maxSpeed; // Максимальная скорость игрока

    private void Start()
    {
        _maxHp = 3; // Установка максимального здоровья
        _hp = _maxHp; // Установка здоровья
        _maxSpeed = 4f; // Установка максимальной скорости
        _speed = _maxSpeed; // Установка скорости
        _score = 0; // Установка очков
    }

    // Проверка какой коллайдер задел игрок
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag; // Получаем тэг объекта, с которым столкнулись
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
}

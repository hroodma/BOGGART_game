using UnityEngine;

public class Player : MonoBehaviour
{

    int _hp; // Здоровье игрока
    int _maxHp = 3; // Максимальное здоровье игрока
    int _score; // Очки игрока
    float _speed; // Скорость игрока
    float _maxSpeed = 4f; // Максимальная скорость игрока

    private void Start()
    {
        _speed = 2f;
    }

    // Проверка какой коллайдер задел игрок
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

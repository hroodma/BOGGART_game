using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected string _nameBonus;
    protected int _pointBonus;

    // Проверка столкновений
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверка на столкновение с игроком
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            player.TakeBonus(_nameBonus, _pointBonus);
        }
    }
}

using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    protected string _nameBonus;
    protected int _pointBonus;

    // �������� ������������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �������� �� ������������ � �������
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            player.TakeBonus(_nameBonus, _pointBonus);
        }
    }
}

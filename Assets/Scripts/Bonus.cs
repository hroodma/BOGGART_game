using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public Spawner spawner; // ������ �� Spawner
    protected string _nameBonus;
    protected int _pointBonus;

    public Transform currentPos;

    // �������� ������������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �������� �� ������������ � �������
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeBonus(_nameBonus, _pointBonus);
                Respawn();
            }
        }
    }

    // ������� ������
    void Respawn()
    {
        int random = Random.Range(0, spawner.spawnPointsBonus.Count);

        // �������� �� ��������� �����
        if (!spawner.busySpawnPointsBonus.Contains(spawner.spawnPointsBonus[random]))
        {
            Transform newPos = spawner.spawnPointsBonus[random];

            spawner.busySpawnPointsBonus.Remove(currentPos);
            transform.position = newPos.position;
            spawner.busySpawnPointsBonus.Add(newPos);
            currentPos = newPos;
        }
        else
        {
            Respawn();
        }
        
    }
}
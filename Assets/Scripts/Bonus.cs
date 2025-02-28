using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public Spawner spawner; // ������ �� Spawner
    public int index;    // ������ ������� ����� ������
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

    void Respawn()
    {
        //// ����������� ������� ����� ������
        //if (busyIndex >= 0 && busyIndex < spawner.spawnPointsBonus.Count)
        //{
        //    spawner.busySpawnPointsBonus.Remove(spawner.spawnPointsBonus[busyIndex]);
        //}

        //// ���� ����� ��������� �����
        //List<Transform> freeSpawnPoints = new List<Transform>();
        //foreach (Transform point in spawner.spawnPointsBonus)
        //{
        //    if (!spawner.busySpawnPointsBonus.Contains(point))
        //    {
        //        freeSpawnPoints.Add(point);
        //    }
        //}

        //if (freeSpawnPoints.Count > 0)
        //{
        //    // �������� ��������� ��������� �����
        //    int randomIndex = Random.Range(0, freeSpawnPoints.Count);
        //    Transform newSpawnPoint = freeSpawnPoints[randomIndex];

        //    // ���������� ����� �� ����� �����
        //    transform.position = newSpawnPoint.position;

        //    // ��������� busySpawnPointsBonus
        //    spawner.busySpawnPointsBonus.Add(newSpawnPoint);
        //    busyIndex = spawner.spawnPointsBonus.IndexOf(newSpawnPoint);
        //}

        int random = Random.Range(0, spawner.spawnPointsBonus.Count);
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
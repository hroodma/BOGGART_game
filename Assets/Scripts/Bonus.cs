using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public Spawner spawner; // Ссылка на Spawner
    public int index;    // Индекс занятой точки спавна
    protected string _nameBonus;
    protected int _pointBonus;

    public Transform currentPos;

    // Проверка столкновений
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверка на столкновение с игроком
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
        //// Освобождаем текущую точку спавна
        //if (busyIndex >= 0 && busyIndex < spawner.spawnPointsBonus.Count)
        //{
        //    spawner.busySpawnPointsBonus.Remove(spawner.spawnPointsBonus[busyIndex]);
        //}

        //// Ищем новую свободную точку
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
        //    // Выбираем случайную свободную точку
        //    int randomIndex = Random.Range(0, freeSpawnPoints.Count);
        //    Transform newSpawnPoint = freeSpawnPoints[randomIndex];

        //    // Перемещаем бонус на новую точку
        //    transform.position = newSpawnPoint.position;

        //    // Обновляем busySpawnPointsBonus
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
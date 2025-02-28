using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> entitiesPrefabs; // Префабы для спавна игрока и врагов
    public List<GameObject> bonusesPrefabs; // Префабы для спавна бонусов
    public Transform spawnPointPlayer; // Точка спавна игрока
    public List<Transform> spawnPointsEnemy; // Точки спавна врагов
    public List<Transform> waypoints; // Конечные точки движения врага
    public List<Transform> spawnPointsBonus; // Точки спавна бонусов
    public List<Transform> busySpawnPointsBonus;  // Занятые точки спавна бонусов

    void Start()
    {
        PlayerSpawn();
        EnemySpawn();
        BonusSpawn();
    }

    // Спавнер игрока
    void PlayerSpawn()
    {
        // Спавним игрока
        Instantiate(entitiesPrefabs[0], spawnPointPlayer.position, spawnPointPlayer.rotation);
    }

    // Спавнер врагов
    void EnemySpawn()
    {
        // Спавним врагов
        for (int i = 0; i < spawnPointsEnemy.Count; i++)
        {
            GameObject enemy = Instantiate(entitiesPrefabs[1], spawnPointsEnemy[i].position, spawnPointsEnemy[i].rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            // Назначаем уникальные точки движения для этого врага
            if (enemyScript != null && i < waypoints.Count)
            {
                enemyScript.SetWaypoints(spawnPointsEnemy[i], waypoints[i]);
            }
        }
    }

    // Спавнер бонусов
    void BonusSpawn()
    {
        // Спавним бонусы
        for (int i = 0; i < bonusesPrefabs.Count; i++)
        {
            int random = Random.Range(0, spawnPointsBonus.Count);

            // Избежание появления нескольких бонусов в одном месте
            if (busySpawnPointsBonus.Contains(spawnPointsBonus[random]))
            {
                i--;
            }
            else
            {
                GameObject bonus = Instantiate(bonusesPrefabs[i], spawnPointsBonus[random].position, spawnPointsBonus[random].rotation);
                busySpawnPointsBonus.Add(spawnPointsBonus[random]);

                Bonus bonusScript = bonus.GetComponent<Bonus>();
                if (bonusScript != null)
                {
                    bonusScript.index = i;
                    bonusScript.spawner = this; // Передаем ссылку на Spawner
                    bonusScript.currentPos = spawnPointsBonus[random];
                }
            }
        }
    }
}
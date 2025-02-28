using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> entitiesPrefabs; // ������� ��� ������ ������ � ������
    public List<GameObject> bonusesPrefabs; // ������� ��� ������ �������
    public Transform spawnPointPlayer; // ����� ������ ������
    public List<Transform> spawnPointsEnemy; // ����� ������ ������
    public List<Transform> waypoints; // �������� ����� �������� �����
    public List<Transform> spawnPointsBonus; // ����� ������ �������
    public List<Transform> busySpawnPointsBonus;  // ������� ����� ������ �������

    void Start()
    {
        PlayerSpawn();
        EnemySpawn();
        BonusSpawn();
    }

    // ������� ������
    void PlayerSpawn()
    {
        // ������� ������
        Instantiate(entitiesPrefabs[0], spawnPointPlayer.position, spawnPointPlayer.rotation);
    }

    // ������� ������
    void EnemySpawn()
    {
        // ������� ������
        for (int i = 0; i < spawnPointsEnemy.Count; i++)
        {
            GameObject enemy = Instantiate(entitiesPrefabs[1], spawnPointsEnemy[i].position, spawnPointsEnemy[i].rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            // ��������� ���������� ����� �������� ��� ����� �����
            if (enemyScript != null && i < waypoints.Count)
            {
                enemyScript.SetWaypoints(spawnPointsEnemy[i], waypoints[i]);
            }
        }
    }

    // ������� �������
    void BonusSpawn()
    {
        // ������� ������
        for (int i = 0; i < bonusesPrefabs.Count; i++)
        {
            int random = Random.Range(0, spawnPointsBonus.Count);

            // ��������� ��������� ���������� ������� � ����� �����
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
                    bonusScript.spawner = this; // �������� ������ �� Spawner
                    bonusScript.currentPos = spawnPointsBonus[random];
                }
            }
        }
    }
}
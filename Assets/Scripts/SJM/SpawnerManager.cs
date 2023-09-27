using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // ������ ���� ������Ʈ ������
    public Transform spawnArea; // ������ ������ Transform

    public float spawnInterval = 5.0f; // ���� ���� (��)
    public int maxSpawnCount = 2; // �ִ� ���� ����
    private int spawnCount = 0; // ���� ������ ����
    private float nextSpawnTime = 0.0f;

    private void Update()
    {
        // ���� ������ ������ �ִ� ���� ������ �������� �ʾ��� ���� ������ �����մϴ�.
        if (spawnCount < maxSpawnCount && Time.time >= nextSpawnTime)
        {
            
            spawnCount++; // ���� ���� ����
            nextSpawnTime = Time.time + spawnInterval; // ���� ���� �ð� ������Ʈ
            SpawnObject();

        }
    }

    private void SpawnObject()
    {
        // ������ ��ġ�� �����ϰ� ����
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
            spawnArea.position.y,
            Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
        );

        // ������ ��ġ�� ���� ������Ʈ ����
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
    }
}



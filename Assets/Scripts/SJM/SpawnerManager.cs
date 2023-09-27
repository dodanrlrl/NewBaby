using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // 스폰할 게임 오브젝트 프리팹
    public Transform spawnArea; // 스폰할 영역의 Transform

    public float spawnInterval = 5.0f; // 스폰 간격 (초)
    public int maxSpawnCount = 2; // 최대 스폰 개수
    private int spawnCount = 0; // 현재 스폰된 개수
    private float nextSpawnTime = 0.0f;

    private void Update()
    {
        // 현재 스폰된 개수가 최대 스폰 개수에 도달하지 않았을 때만 스폰을 실행합니다.
        if (spawnCount < maxSpawnCount && Time.time >= nextSpawnTime)
        {
            
            spawnCount++; // 스폰 개수 증가
            nextSpawnTime = Time.time + spawnInterval; // 다음 스폰 시간 업데이트
            SpawnObject();

        }
    }

    private void SpawnObject()
    {
        // 스폰할 위치를 랜덤하게 선택
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
            spawnArea.position.y,
            Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
        );

        // 선택한 위치에 게임 오브젝트 스폰
        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
    }
}



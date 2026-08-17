using Unity.VisualScripting;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public GameObject spawnedPrefab;
    public float minSpawnInterval = 10f;
    public float maxSpawnInterval = 20f;
    public float spawnHeight = 0.03f;
    [HideInInspector] public float nextSpawnTime;

    [SerializeField] private GameObject _currentSpawned;
    public bool isSpawned;
    public LayerMask enemyLayer;

    private void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsGameActive) return;

        DetectSpawnedObject();

        if (isSpawned) return;
        else if(!isSpawned && Time.time >= nextSpawnTime)
        {
            SpawnObject(spawnedPrefab);
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
        else if(Time.time >= nextSpawnTime && isSpawned)
        {
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void DetectSpawnedObject()
    {
        if(isSpawned)
        {
            var ray = new Ray(transform.position, transform.up);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f, enemyLayer))
            {
                _currentSpawned = hit.transform.gameObject;
            }
            else
            {
                _currentSpawned = null;
                isSpawned = false;
            }
        }
    }

    void SpawnObject(GameObject prefab)
    {
        Vector3 spawnLoc = new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z);
        Instantiate(prefab, spawnLoc, Quaternion.identity);
        isSpawned = true;
    }

}

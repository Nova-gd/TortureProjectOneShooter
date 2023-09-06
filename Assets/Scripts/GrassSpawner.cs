using UnityEngine;

[System.Serializable]
public class GrassPrefab
{
    public GameObject prefab;
    public float spawnProbability;
}

public class GrassSpawner : MonoBehaviour
{
    public GrassPrefab[] grassPrefabs;
    public int numberOfGrassObjects = 100;
    public float spawnRadius = 10f;

    void Start()
    {
        SpawnGrass();
    }

    void SpawnGrass()
    {
        for (int i = 0; i < numberOfGrassObjects; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnPlane();
            GameObject selectedPrefab = SelectRandomPrefab();
            Instantiate(selectedPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPositionOnPlane()
    {
        Vector3 planeCenter = transform.position;
        Vector3 randomPoint = planeCenter + new Vector3(Random.Range(-spawnRadius, spawnRadius), 0f, Random.Range(-spawnRadius, spawnRadius));
        return randomPoint;
    }

    GameObject SelectRandomPrefab()
    {
        float totalProbability = 0f;
        foreach (var grassPrefab in grassPrefabs)
        {
            totalProbability += grassPrefab.spawnProbability;
        }

        float randomValue = Random.value * totalProbability;

        foreach (var grassPrefab in grassPrefabs)
        {
            if (randomValue < grassPrefab.spawnProbability)
            {
                return grassPrefab.prefab;
            }
            randomValue -= grassPrefab.spawnProbability;
        }

        return null;
    }
}

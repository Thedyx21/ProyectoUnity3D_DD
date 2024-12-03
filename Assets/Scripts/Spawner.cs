using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // El prefab a instanciar
    public float spawnIntervalMin = 1f; // Tiempo mínimo entre spawns
    public float spawnIntervalMax = 5f; // Tiempo máximo entre spawns
    public float spawnRange = 1000000f; // Rango aleatorio de spawn en X y Z

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (true)
        {
            Vector3 randomPosition = new Vector3(
                transform.position.x + Random.Range(-spawnRange, spawnRange),
                transform.position.y,
                transform.position.z + Random.Range(-spawnRange, spawnRange)
            );

            Instantiate(prefab, randomPosition, Quaternion.identity);

            float randomInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
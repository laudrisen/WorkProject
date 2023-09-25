using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Префаб зомби

    public int numberOfZombies = 3; // Количество зомби для спавна
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); // Размер области для спавна

    private void Start()
    {
        // Генерация зомби в рандомных позициях
        for (int i = 0; i < numberOfZombies; i++)
        {
            Vector2 randomSpawnPosition = new Vector2(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

            GameObject newZombie = Instantiate(zombiePrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}

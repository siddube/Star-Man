using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
  [SerializeField] private GameObject[] asteroids;
  [SerializeField] private float secondsBetweenAsteroids;
  [SerializeField] private Vector2 forceRange;

  private float timer;
  private Camera mainCamera;

  private void Start()
  {
    mainCamera = Camera.main;
  }
  private void Update()
  {
    timer -= Time.deltaTime;
    if (timer <= 0)
    {
      SpawnAsteroid();

      timer += secondsBetweenAsteroids;
    }
  }

  private void SpawnAsteroid()
  {
    int side = Random.Range(0, 4);

    Vector2 spawnPoint = Vector2.zero;
    Vector2 direction = Vector2.zero;

    switch (side)
    {
      case 0:
        //Top
        spawnPoint.x = Random.value;
        spawnPoint.y = 1;
        direction = new Vector2(Random.Range(-1f, 1f), -1f);
        break;
      case 1:
        //Right
        spawnPoint.x = 1;
        spawnPoint.y = Random.value;
        direction = new Vector2(-1f, Random.Range(-1f, 1f));
        break;
      case 2:
        //Bottom
        spawnPoint.x = Random.value;
        spawnPoint.y = 0;
        direction = new Vector2(Random.Range(-1f, 1f), 1f);
        break;
      case 3:
        //Left
        spawnPoint.x = 0;
        spawnPoint.y = Random.value;
        direction = new Vector2(1f, Random.Range(-1f, 1f));
        break;
    }

    Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
    worldSpawnPoint.z = 0;

    GameObject selectedAsteroid = asteroids[Random.Range(0, asteroids.Length)];

    GameObject asteroidInstance = Instantiate(
        selectedAsteroid,
        worldSpawnPoint,
        Quaternion.Euler(0f, 0f, Random.Range(0, 360))
    );

    Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

    rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
  }
}

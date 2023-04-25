using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuHandler : MonoBehaviour
{
  [SerializeField] GameObject gameOverUI;
  [SerializeField] AsteroidSpawner asteroidSpawner;

  public void EndGame()
  {
    asteroidSpawner.enabled = false;
    gameOverUI.SetActive(true);
  }
  public void PlayGame()
  {
    SceneManager.LoadScene(1);
  }

  public void ReturnToMenu()
  {
    SceneManager.LoadScene(0);
  }
}

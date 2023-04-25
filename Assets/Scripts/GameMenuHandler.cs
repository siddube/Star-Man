using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenuHandler : MonoBehaviour
{
  [SerializeField] ScoreSystem scoreSystem;
  [SerializeField] TMP_Text levelScoreText;
  [SerializeField] GameObject gameOverUI;
  [SerializeField] AsteroidSpawner asteroidSpawner;

  public void EndGame()
  {
    asteroidSpawner.enabled = false;
    gameOverUI.SetActive(true);
    int finalScore = scoreSystem.EndScoreCount();
    levelScoreText.text = $"Your Score: {finalScore}";
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuHandler : MonoBehaviour
{
  public void PlayGame()
  {
    SceneManager.LoadScene(1);
  }

  public void ReturnToMenu()
  {
    SceneManager.LoadScene(0);
  }
}

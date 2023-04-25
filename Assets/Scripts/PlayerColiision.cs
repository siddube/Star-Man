using UnityEngine;

public class PlayerColiision : MonoBehaviour
{
  [SerializeField] GameMenuHandler gameMenuHandler;
  public void Crash()
  {
    this.gameObject.SetActive(false);
    gameMenuHandler.gameObject.SetActive(true);
  }

}

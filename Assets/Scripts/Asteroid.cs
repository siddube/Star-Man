using UnityEngine;

public class Asteroid : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    PlayerColiision playerColiision = other.GetComponent<PlayerColiision>();

    if (playerColiision == null) { return; }
    playerColiision.Crash();
  }
}

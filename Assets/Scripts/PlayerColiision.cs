using UnityEngine;

public class PlayerColiision : MonoBehaviour
{
  public void Crash()
  {
    this.gameObject.SetActive(false);
  }

}

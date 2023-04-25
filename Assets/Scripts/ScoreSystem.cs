using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
  [SerializeField] private TMP_Text scoreText;
  [SerializeField] int scoreMultiplier;
  private float score;
  private bool shouldCount = true;
  private void Update()
  {
    if (!shouldCount) { return; }
    score += Time.deltaTime * scoreMultiplier;
    scoreText.text = Mathf.FloorToInt(score).ToString();
  }

  public int EndScoreCount()
  {
    Debug.Log("Ending game");
    shouldCount = false;
    scoreText.text = string.Empty;

    return Mathf.FloorToInt(score);
  }
}

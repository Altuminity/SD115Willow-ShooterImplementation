using UnityEngine;

public class SentryGiveScore : MonoBehaviour
{
    public int score;
    public void AddScore()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.AddScore(score);
    }
}

using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;

    // UI가 SetActive 할 때 호출되는 함수 
    private void OnEnable()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (GameManager.score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", GameManager.score);
            bestScore = GameManager.score;
        }
        bestScoreText.text = bestScore.ToString();
        scoreText.text = GameManager.score.ToString();
    }
}

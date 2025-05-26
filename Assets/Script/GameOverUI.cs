using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;

    // UI�� SetActive �� �� ȣ��Ǵ� �Լ� 
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

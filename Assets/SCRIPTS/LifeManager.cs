using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LifeManager : MonoBehaviour
{
    [SerializeField] int totalLives;
    private int currentLives;
    private int currentAILives;

    [SerializeField] Image[] lifeIcons;
    [SerializeField] Image[] aiLifeIcons;

    [SerializeField] ScoreManager scoreManager;
    [Header("Win/Lose Condition")]
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI wintext;

    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject WinPanel;

    void Start()
    {
        currentLives = totalLives;
        currentAILives = totalLives;

        gameOverText.gameObject.SetActive(false);

        UpdateLifeDisplay();
    }


    public void LosePlayerLife()
    {
        currentLives--;

        UpdateLifeDisplay();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    public void LoseAILife()
    {
        currentAILives--;
        UpdateLifeDisplay();

        if (currentAILives <= 0)
        {
            WinGame("AI Lost All Its Lives. You Win!");
        }
    }

    private void UpdateLifeDisplay()
    {
        UpdateLifeIcons(lifeIcons, currentLives);
        UpdateLifeIcons(aiLifeIcons, currentAILives);
    }

    private void UpdateLifeIcons(Image[] lifeIconsArray, int currentLives)
    {
        int totalIcons = lifeIconsArray.Length;
        float livesPerIcon = (float)totalLives / totalIcons;

        int remainingLives = currentLives; 

        for (int i = 0; i < totalIcons; i++)
        {
            if (remainingLives > 0)
            {
                float fillAmount = Mathf.Min(1f, (float)remainingLives / livesPerIcon);
                lifeIconsArray[i].enabled = true;
                lifeIconsArray[i].fillAmount = fillAmount;

                remainingLives -= Mathf.FloorToInt(livesPerIcon);
            }
            else
            {
                lifeIconsArray[i].enabled = false;
            }
        }
    }


    private void WinGame(string message)
    {
        gameOverText.gameObject.SetActive(false);  
        wintext.gameObject.SetActive(true);
        WinPanel.SetActive(true); 

        scoreManager.winPlayerScoreText.text = "Player: " + scoreManager.GetCurrentPlayerScore();
        scoreManager.winAIScoreText.text = "AI: " + scoreManager.GetCurrentAiScore();
        scoreManager.winRoundText.text = "Round: " + scoreManager.GetCurrentRound();  
        wintext.text = message;
    }

    private void GameOver()
    {
        WinPanel.SetActive(false);  // Hide win panel
        GameOverPanel.SetActive(true);  // Show game over panel
        gameOverText.gameObject.SetActive(true);

        scoreManager.gameOverRoundText.text = "Round: " + scoreManager.GetCurrentRound();  
        scoreManager.gameOverPlayerScoreText.text = "Player: " + scoreManager.GetCurrentPlayerScore();
        scoreManager.gameOverAIScoreText.text = "AI: " + scoreManager.GetCurrentAiScore();

        gameOverText.text = "Game Over! You Lost All Your Lives!";
    }
}

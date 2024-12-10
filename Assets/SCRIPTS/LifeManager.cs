using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public enum GameMode { PlayerVsPlayer, PlayerVsAI }
    [Header("Health Manager")]

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

    [Header("Game Mode")]
    [SerializeField] GameMode currentGameMode;

    void Start()
    {
        currentLives = totalLives;
        currentAILives = totalLives;

        gameOverText.gameObject.SetActive(false);

        UpdateLifeDisplay();
    }

    public void LosePlayerLife()
    {
        if (currentGameMode == GameMode.PlayerVsAI)
        {
            currentLives--;
            UpdateLifeDisplay();

            if (currentLives <= 0)
            {
                GameOver("Player Lost All Its Lives. You Lose.");
            }
        }
        else if (currentGameMode == GameMode.PlayerVsPlayer)
        {
            currentLives--;
            UpdateLifeDisplay();
            if (currentLives <= 0)
            {
                GameOver("Player 1 Lost All Its Lives. Player 2 Wins!");
            }
        }
    }

    public void LoseAILife()
    {
        if (currentGameMode == GameMode.PlayerVsAI)
        {
            currentAILives--;
            UpdateLifeDisplay();

            if (currentAILives <= 0)
            {
                WinGame("AI Lost All Its Lives. You Win!");
            }
           
        }
        else if (currentGameMode == GameMode.PlayerVsPlayer)
        {
            currentAILives--;
            UpdateLifeDisplay();

            if (currentAILives <= 0)
            {
                WinGame("Player 2 Lost All Its Lives. Player 1 Wins!");
            }
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

        scoreManager.winAIScoreText.text = "Player 2: " + scoreManager.GetCurrentPlayer2Score();
        wintext.text = message;
    }

    private void GameOver(string message)
    {
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);

        scoreManager.gameOverRoundText.text = "Round: " + scoreManager.GetCurrentRound();
        scoreManager.gameOverPlayerScoreText.text = "Player: " + scoreManager.GetCurrentPlayerScore();
        scoreManager.gameOverAIScoreText.text = "AI: " + scoreManager.GetCurrentAiScore();

        scoreManager.gameOverAIScoreText.text = "Player 2: " + scoreManager.GetCurrentPlayer2Score();
        gameOverText.text = message;
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public enum GameMode { PlayerVsPlayer, PlayerVsAI }

    private int playerScore = 0;
    private int playerScore2 = 0;
    private int aiScore = 0;
    private int currentRound = 1;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI roundText;

    [Header("GAME OVER")]
    public TextMeshProUGUI gameOverPlayerScoreText;
    public TextMeshProUGUI gameOverAIScoreText;
    public TextMeshProUGUI gameOverRoundText;

    [Header("WIN")]
    public TextMeshProUGUI winPlayerScoreText;
    public TextMeshProUGUI winAIScoreText;
    public TextMeshProUGUI winRoundText;

    [Header("Game Mode")]
    [SerializeField] GameMode currentGameMode;

    public void UpdatePlayerScore()
    {
        playerScore++;
        UpdateScoreUI();
    }

    public void UpdatePlayer2Score()
    {
        playerScore2++;
        UpdateScoreUI();
    }

    public void UpdateAIScore()
    {
        aiScore++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (currentGameMode == GameMode.PlayerVsPlayer)
        {
            playerScoreText.text = "Player 1: " + playerScore;
            player2ScoreText.text = "Player 2: " + playerScore2;
        }
        if (currentGameMode == GameMode.PlayerVsAI)
        {
            playerScoreText.text = "Player: " + playerScore;
            aiScoreText.text = "AI: " + aiScore;
        }

        roundText.text = "Round: " + currentRound;
    }

    public void ResetScores()
    {
        playerScore = 0;
        playerScore2 = 0;
        aiScore = 0;
        currentRound = 1;
        UpdateScoreUI();
    }

    public void NextRound()
    {
        currentRound++;
        UpdateScoreUI();
    }

    public int GetCurrentRound() { return currentRound; }
    public int GetCurrentPlayerScore() { return playerScore; }
    public int GetCurrentPlayer2Score() { return playerScore2; }
    public int GetCurrentAiScore() { return aiScore; }
}

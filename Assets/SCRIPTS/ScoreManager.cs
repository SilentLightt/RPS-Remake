using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public enum GameMode { PlayerVsPlayer, PlayerVsAI }

    private int playerScore = 0;
    private int aiScore = 0;
    private int currentRound = 1;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI roundText; // Round display

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

    public void UpdateAIScore()
    {
        aiScore++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        playerScoreText.text = "Player: " + playerScore;
        aiScoreText.text = "AI: " + aiScore;
        roundText.text = "Round: " + currentRound;
    }

    public void ResetScores()
    {
        playerScore = 0;
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
    public int GetCurrentAiScore() { return aiScore; }
}

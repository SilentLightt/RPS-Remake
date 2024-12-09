using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Player and AI scores
    private int playerScore = 0;
    private int aiScore = 0;

    // Round counter
    private int currentRound = 1;

    // UI Texts to display the scores and round number
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI roundText; // Round display

    [Header("GAME OVER PANEL")]
    public TextMeshProUGUI gameOverPlayerScoreText;
    public TextMeshProUGUI gameOverAIScoreText;
    public TextMeshProUGUI gameOverRoundText;

    [Header("WIN PANEL")]
    public TextMeshProUGUI winPlayerScoreText;
    public TextMeshProUGUI winAIScoreText;
    public TextMeshProUGUI winRoundText;

    // Function to update the player's score
    public void UpdatePlayerScore()
    {
        playerScore++;
        UpdateScoreUI();
    }

    // Function to update the AI's score
    public void UpdateAIScore()
    {
        aiScore++;
        UpdateScoreUI();
    }

    // Function to update the UI display of the scores and round
    private void UpdateScoreUI()
    {
        playerScoreText.text = "Player: " + playerScore;
        aiScoreText.text = "AI: " + aiScore;
        roundText.text = "Round: " + currentRound;  // Update round text
    }

    // Function to reset both scores to zero and reset round to 1
    public void ResetScores()
    {
        playerScore = 0;
        aiScore = 0;
        currentRound = 1;  // Reset the round to 1
        UpdateScoreUI();
    }

    // Function to go to the next round
    public void NextRound()
    {
        currentRound++;
        UpdateScoreUI();  // Update round text when advancing to next round
    }
    public int GetCurrentRound()
    {
        return currentRound;
    }
    public int GetCurrentPlayerScore() { return playerScore; }
    public int GetCurrentAiScore() { return aiScore; }

}

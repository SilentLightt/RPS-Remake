using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Player and AI scores
    private int playerScore = 0;
    private int aiScore = 0;

    // UI Texts to display the scores
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;

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

    // Function to update the UI display of the scores
    private void UpdateScoreUI()
    {
        playerScoreText.text = "Player: " + playerScore;
        aiScoreText.text = "AI: " + aiScore;
    }

    // Function to reset both scores to zero
    public void ResetScores()
    {
        playerScore = 0;
        aiScore = 0;
        UpdateScoreUI();
    }
}

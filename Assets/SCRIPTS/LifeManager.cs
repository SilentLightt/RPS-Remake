using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LifeManager : MonoBehaviour
{
    // The player's current life (initial value)
    public int totalLives = 3;
    private int currentLives;
    private int currentAILives;

    // Image array to display the life icons (e.g., hearts)
    public Image[] lifeIcons;
    public Image[] aiLifeIcons;

    // Reference to ScoreManager
    public ScoreManager scoreManager;

    // UI Text for game over message
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI wintext;

    public GameObject GameOverPanel;
    public GameObject WinPanel;

    void Start()
    {
        // Initialize the player's life at the start
        currentLives = totalLives;
        currentAILives = totalLives;

        // Hide the game over text initially
        gameOverText.gameObject.SetActive(false);

        // Update the life icons to match the starting lives
        UpdateLifeDisplay();
    }

    // Function to handle when the player loses a round (life decreases)
    public void LosePlayerLife()
    {
        // Decrease the player's life
        currentLives--;

        // Update the life icons display
        UpdateLifeDisplay();

        // Check if the player is out of lives (Game Over)
        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    public void LoseAILife()
    {
        currentAILives--;
        UpdateLifeDisplay();

        // Check if the AI is out of lives (Player wins)
        if (currentAILives <= 0)
        {
            WinGame("AI Lost All Its Lives. You Win!");
        }
    }
    // Function to update the life icons UI
    private void UpdateLifeDisplay()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < currentLives)
            {
                lifeIcons[i].enabled = true; // Show life icon
            }
            else
            {
                lifeIcons[i].enabled = false; // Hide life icon
            }
        }
        for (int i = 0; i < aiLifeIcons.Length; i++)
        {
            if (i < currentAILives)
            {
                aiLifeIcons[i].enabled = true; // Show AI life icon
            }
            else
            {
                aiLifeIcons[i].enabled = false; // Hide AI life icon
            }
        }
    }
    private void WinGame(string message)
    {
        gameOverText.gameObject.SetActive(true);
        wintext.text = message;
        GameOverPanel.SetActive(false);
        WinPanel.SetActive(true);
    }
    // Function to handle game over scenario
    private void GameOver()
    {
        // Show the game over message
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over! You Lost All Your Lives!";
        GameOverPanel.SetActive(true);
        
        //Time.timeScale = 0;
        // Reset the score and life after a brief delay (optional)
        //StartCoroutine(ResetGame());
    }

    // Function to reset the game (score and life)
    //private IEnumerator ResetGame()
    //{
    //    yield return new WaitForSeconds(2f); // Wait before resetting

    //    // Reset life
    //    currentLives = totalLives;
    //    UpdateLifeDisplay();

    //    // Reset score (you may decide to reset the score, or leave it as is)
    //    scoreManager.ResetScores();

    //    // Hide game over message
    //    gameOverText.gameObject.SetActive(false);
    //}
}

//~~~~ORIGINAL SCRIPT~~~~~~~~~~//
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class RockPaperScissors : MonoBehaviour
//{
//    public enum Move { Rock, Paper, Scissors }

//    // Dictionary to store the result of each interaction
//    private Dictionary<(Move, Move), string> gameResults;

//    // Buttons for each move
//    public Button rockButton;
//    public Button paperButton;
//    public Button scissorsButton;

//    // Images to display player and AI moves
//    public Image playerMoveImage;
//    public Image aiMoveImage;
//    public Image resultImage;

//    // Images for Rock, Paper, Scissors, Win, Lose, Draw
//    public Sprite rockSprite;
//    public Sprite paperSprite;
//    public Sprite scissorsSprite;
//    public Sprite winSprite;
//    public Sprite loseSprite;
//    public Sprite drawSprite;

//    // Delay time
//    public float moveDelay = 1f; // Delay in seconds

//    // Waiting text and button lock
//    public Text waitingText;

//    void Start()
//    {
//        // Initialize the dictionary to define outcomes
//        gameResults = new Dictionary<(Move, Move), string>
//        {
//            { (Move.Rock, Move.Rock), "Draw" },
//            { (Move.Rock, Move.Paper), "Paper beats Rock. You Lose!" },
//            { (Move.Rock, Move.Scissors), "Rock beats Scissors. You Win!" },

//            { (Move.Paper, Move.Rock), "Paper beats Rock. You Win!" },
//            { (Move.Paper, Move.Paper), "Draw" },
//            { (Move.Paper, Move.Scissors), "Scissors beats Paper. You Lose!" },

//            { (Move.Scissors, Move.Rock), "Rock beats Scissors. You Lose!" },
//            { (Move.Scissors, Move.Paper), "Scissors beats Paper. You Win!" },
//            { (Move.Scissors, Move.Scissors), "Draw" }
//        };

//        // Assign button listeners
//        rockButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay(Move.Rock)));
//        paperButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay(Move.Paper)));
//        scissorsButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay(Move.Scissors)));

//        // Initially hide waiting text
//        waitingText.gameObject.SetActive(false);
//    }

//    // Function to simulate player vs AI move with delay
//    private IEnumerator PlayWithDelay(Move playerMove)
//    {
//        // Disable buttons to prevent further input
//        rockButton.interactable = false;
//        paperButton.interactable = false;
//        scissorsButton.interactable = false;

//        // Display the player's move immediately
//        playerMoveImage.sprite = GetMoveSprite(playerMove);

//        // Show the waiting message
//        waitingText.gameObject.SetActive(true);
//        waitingText.text = "Please wait for AI's move...";

//        // Wait for a brief moment (this is the delay)
//        yield return new WaitForSeconds(moveDelay);

//        // AI makes a random move
//        Move aiMove = (Move)Random.Range(0, 3);

//        // Get the result from the dictionary
//        string result = gameResults[(playerMove, aiMove)];

//        // Set the AI's move image
//        aiMoveImage.sprite = GetMoveSprite(aiMove);

//        // Set the result image
//        resultImage.sprite = GetResultSprite(result);

//        // Show the result message
//        waitingText.text = result;

//        // Re-enable buttons after a short delay
//        yield return new WaitForSeconds(1f);  // Additional delay to show the result
//        rockButton.interactable = true;
//        paperButton.interactable = true;
//        scissorsButton.interactable = true;

//        // Hide the waiting message
//        waitingText.gameObject.SetActive(false);
//    }

//    // Function to get the sprite for each move
//    private Sprite GetMoveSprite(Move move)
//    {
//        switch (move)
//        {
//            case Move.Rock: return rockSprite;
//            case Move.Paper: return paperSprite;
//            case Move.Scissors: return scissorsSprite;
//            default: return null;
//        }
//    }

//    // Function to get the result sprite (Win, Lose, Draw)
//    private Sprite GetResultSprite(string result)
//    {
//        if (result.Contains("Win"))
//        {
//            return winSprite;
//        }
//        else if (result.Contains("Lose"))
//        {
//            return loseSprite;
//        }
//        else
//        {
//            return drawSprite;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RockPaperScissors : MonoBehaviour
{
    public enum Move { Rock, Paper, Scissors }

    private Dictionary<(Move, Move), string> gameResults;
    
    [Header("BUTTONS MANAGER")]
    [SerializeField] Button rockButton;
    [SerializeField] Button paperButton;
    [SerializeField] Button scissorsButton;
    
    [Header("IMAGE DISPLAY")]
    [SerializeField] Image playerMoveImage;
    [SerializeField] Image aiMoveImage;
    [SerializeField] Image resultImage;
    
    [Header("SPRITE DISPLAY")]
    [SerializeField] Sprite rockSprite;
    [SerializeField] Sprite paperSprite;
    [SerializeField] Sprite scissorsSprite;

    [Header("TEXT DISPLAY")]
    [SerializeField] private float moveDelay; // Delay in seconds
    [SerializeField] private TextMeshProUGUI waitingText;
    [SerializeField] GameObject LoadingObject;
    public ScoreManager scoreManager;
    public LifeManager lifeManager;

    void Start()
    {
       LoadingObject.SetActive(false);
        gameResults = new Dictionary<(Move, Move), string>
        {
            { (Move.Rock, Move.Rock), "Draw" },
            { (Move.Rock, Move.Paper), "Paper beats Rock. You Lose!" },
            { (Move.Rock, Move.Scissors), "Rock beats Scissors. You Win!" },

            { (Move.Paper, Move.Rock), "Paper beats Rock. You Win!" },
            { (Move.Paper, Move.Paper), "Draw" },
            { (Move.Paper, Move.Scissors), "Scissors beats Paper. You Lose!" },

            { (Move.Scissors, Move.Rock), "Rock beats Scissors. You Lose!" },
            { (Move.Scissors, Move.Paper), "Scissors beats Paper. You Win!" },
            { (Move.Scissors, Move.Scissors), "Draw" }
        };


        rockButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay(Move.Rock)));
        paperButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay(Move.Paper)));
        scissorsButton.onClick.AddListener(() => StartCoroutine(PlayWithDelay(Move.Scissors)));
        waitingText.gameObject.SetActive(false);

    }


    private IEnumerator PlayWithDelay(Move playerMove)
    {
        // Disable buttons to prevent further input
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;

        // Display the player's move immediately
        playerMoveImage.sprite = GetMoveSprite(playerMove);

        // Show the waiting message
        waitingText.gameObject.SetActive(true);
        LoadingObject.gameObject.SetActive(true);
        waitingText.text = "Please wait for AI's move...";

        // Wait for a brief moment (this is the delay)
        yield return new WaitForSeconds(moveDelay);

        // AI makes a random move
        Move aiMove = (Move)Random.Range(0, 3);

        // Get the result from the dictionary
        string result = gameResults[(playerMove, aiMove)];

        // Set the AI's move image
        aiMoveImage.sprite = GetMoveSprite(aiMove);

        // Set the result message in the waiting text
        waitingText.text = result;
        if (result.Contains("You Win"))
        {
            scoreManager.UpdatePlayerScore(); // Player wins
            lifeManager.LoseAILife();
        }
        else if (result.Contains("You Lose"))
        {
            scoreManager.UpdateAIScore(); // AI wins
            lifeManager.LosePlayerLife(); // Player loses a life
        }
        // Re-enable buttons after a short delay
        yield return new WaitForSeconds(1f);  // Additional delay to show the result
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;

        // Hide the waiting message
        waitingText.gameObject.SetActive(false);
        LoadingObject.gameObject.SetActive(false);

    }

    // Function to get the sprite for each move
    private Sprite GetMoveSprite(Move move)
    {
        switch (move)
        {
            case Move.Rock: return rockSprite;
            case Move.Paper: return paperSprite;
            case Move.Scissors: return scissorsSprite;
            default: return null;
        }
    }
}

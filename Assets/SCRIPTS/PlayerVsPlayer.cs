using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerVsPlayer : MonoBehaviour
{
    public enum Move { Rock, Paper, Scissors }

    private Dictionary<(Move, Move), string> gameResults;

    [Header("BUTTONS MANAGER")]
    [SerializeField] Button rockButton;
    [SerializeField] Button paperButton;
    [SerializeField] Button scissorsButton;

    [SerializeField] Button rockButtonPlayer2;
    [SerializeField] Button paperButtonPlayer2;
    [SerializeField] Button scissorsButtonPlayer2;

    [Header("IMAGE DISPLAY")]
    [SerializeField] Image playerOneMoveImage;
    [SerializeField] Image playerTwoMoveImage;
    [SerializeField] Image resultImage;

    [Header("SPRITE DISPLAY")]
    [SerializeField] Sprite rockSprite;
    [SerializeField] Sprite paperSprite;
    [SerializeField] Sprite scissorsSprite;
    [SerializeField] Sprite questionMarkSprite;

    [Header("TEXT DISPLAY")]
    [SerializeField] private float moveDelay;
    [SerializeField] private TextMeshProUGUI waitingText;
    [SerializeField] GameObject loadingObject;

    [Header("GAME MANAGERS")]
    public ScoreManager scoreManager;
    public LifeManager lifeManager;

    private bool isPlayerOneTurn = true; 
    private Move playerOneMove;
    private Move playerTwoMove;
    private Move playerOneStoredMove; 

    void Start()
    {
        loadingObject.SetActive(false);
        gameResults = new Dictionary<(Move, Move), string>
        {
            { (Move.Rock, Move.Rock), "Draw" },
            { (Move.Rock, Move.Paper), "Paper beats Rock. Player 2 Wins!" },
            { (Move.Rock, Move.Scissors), "Rock beats Scissors. Player 1 Wins!" },

            { (Move.Paper, Move.Rock), "Paper beats Rock. Player 1 Wins!" },
            { (Move.Paper, Move.Paper), "Draw" },
            { (Move.Paper, Move.Scissors), "Scissors beats Paper. Player 2 Wins!" },

            { (Move.Scissors, Move.Rock), "Rock beats Scissors. Player 2 Wins!" },
            { (Move.Scissors, Move.Paper), "Scissors beats Paper. Player 1 Wins!" },
            { (Move.Scissors, Move.Scissors), "Draw" }
        };

        rockButton.onClick.AddListener(() => OnPlayerMove(Move.Rock,1));
        paperButton.onClick.AddListener(() => OnPlayerMove(Move.Paper, 1));
        scissorsButton.onClick.AddListener(() => OnPlayerMove(Move.Scissors, 1));

        rockButtonPlayer2.onClick.AddListener(() => OnPlayerMove(Move.Rock, 2));
        paperButtonPlayer2.onClick.AddListener(() => OnPlayerMove(Move.Paper, 2));
        scissorsButtonPlayer2.onClick.AddListener(() => OnPlayerMove(Move.Scissors, 2));

        waitingText.gameObject.SetActive(false);
    }

    private void OnPlayerMove(Move move, int player)
    {
        if (player == 1 && isPlayerOneTurn)
        {
            playerOneMove = move;
            playerOneStoredMove = move; 
            playerOneMoveImage.sprite = questionMarkSprite; 
            waitingText.text = "Player 2's Turn...";
            waitingText.gameObject.SetActive(true); 
            loadingObject.SetActive(true); 
            LockPlayerButtons(true); 
            isPlayerOneTurn = false;
        }
        else if (player == 2 && !isPlayerOneTurn)
        {
            playerTwoMove = move;
            playerTwoMoveImage.sprite = GetMoveSprite(move);
            waitingText.text = "Calculating Result...";
            StartCoroutine(ShowResult());
        }
    }

    private void LockPlayerButtons(bool isLocked)
    {
        rockButton.interactable = !isLocked;
        paperButton.interactable = !isLocked;
        scissorsButton.interactable = !isLocked;

        rockButtonPlayer2.interactable = isLocked;
        paperButtonPlayer2.interactable = isLocked;
        scissorsButtonPlayer2.interactable = isLocked;
    }

    private IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(moveDelay);

        string result = gameResults[(playerOneMove, playerTwoMove)];
        waitingText.text = result;

        if (result.Contains("Player 1 Wins"))
        {
            scoreManager.UpdatePlayerScore();
            lifeManager.LoseAILife();
        }
        else if (result.Contains("Player 2 Wins"))
        {
            scoreManager.UpdatePlayer2Score();
            lifeManager.LosePlayerLife();
        }
        playerOneMoveImage.sprite = GetMoveSprite(playerOneStoredMove); // Use the stored move

        scoreManager.NextRound();

        yield return new WaitForSeconds(1f);

        // Reset for the next round
        isPlayerOneTurn = true;
        waitingText.text = "Player 1's Turn...";

        // Hide loading and waiting text
        waitingText.gameObject.SetActive(false);
        loadingObject.SetActive(false);

        // Unlock buttons for Player 1's next turn
        LockPlayerButtons(false);

        // Show Player 1's actual move after the round is finished
    }


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

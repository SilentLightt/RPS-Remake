using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageGame : MonoBehaviour
{
    public Text Result;
    public Image AIChoice;

    public GameObject GameScreen;
    public GameObject WinScreen;
    public GameObject LoseScreen;

    public TextMeshProUGUI myscoredisplay, aiscoredisplay;
    public int yourscore, aiscore;

    public string[] Choices;
    public Sprite Rock, Paper, Scissors;


    public void Play(string myChoice)
    {

        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        switch (randomChoice)
        {
            case "Rock":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "Tie!";
                        break;

                    case "Paper":
                        Result.text = "Skillful play in using the paper, you win a round!";
                        yourscore += 1;
                        myscoredisplay.SetText(yourscore.ToString());
                        break;

                    case "Scissors":
                        Result.text = "The Robots rock absolutely annihilates the scissors, you lose a round!";
                        aiscore += 1;
                        aiscoredisplay.SetText(aiscore.ToString());
                        break;

                }

                AIChoice.sprite = Rock;
                break;

            case "Paper":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "The Robot's paper eats your rock.... you lose a round!";
                        aiscore += 1;
                        aiscoredisplay.SetText(aiscore.ToString());
                        break;

                    case "Paper":
                        Result.text = "Tie!";
                        break;

                    case "Scissors":
                        Result.text = "You used the scissors effectively against the Robot's paper, the robot must be sweating with those blades!";
                        yourscore += 1;
                        myscoredisplay.SetText(yourscore.ToString());
                        break;

                }

                AIChoice.sprite = Paper;
                break;

            case "Scissors":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "The Robot played scissors against the rock knowing full well it won't penetrate, will this be the moment?";
                        yourscore += 1;
                        myscoredisplay.SetText(yourscore.ToString());
                        break;

                    case "Paper":
                        Result.text = "The Robot strikes a scissors against your paper knowing full well it won't shield you, do you need a reality check?";
                        aiscore += 1;
                        aiscoredisplay.SetText(aiscore.ToString());
                        break;

                    case "Scissors":
                        Result.text = "Tie!";
                        break;

                }

                AIChoice.sprite = Scissors;
                break;
        }
                if (yourscore == 3)
                {
                    GameScreen.SetActive(false);
                    WinScreen.SetActive(true);
                }
                else if (aiscore == 3)
                {
                    GameScreen.SetActive(false);
                    LoseScreen.SetActive(true);
                }

        }
    }

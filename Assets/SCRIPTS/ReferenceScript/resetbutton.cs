using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetbutton : MonoBehaviour
{
    // Start is called before the first frame update

    // Function to reset the game
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game restarting...");
    }

}
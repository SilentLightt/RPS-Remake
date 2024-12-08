using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;       
    private string SceneName;
    private int currentPanelIndex = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        ShowPanel(0);
    }
    public void ShowPanel(int panelIndex)
    {
        foreach (var panel in menuPanels)
        {
            panel.SetActive(false);
        }
        menuPanels[panelIndex].SetActive(true);
        currentPanelIndex = panelIndex;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public IEnumerator PauseDelay() 
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(0.4f);
        //PauseMenu();
    }
    public void PauseMenu()
    {
        PauseDelay();
    }
    public void ResumeMenu()
    {
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackButton()
    {
        int previousPanelIndex = Mathf.Max(currentPanelIndex - 1, 0);
        ShowPanel(previousPanelIndex);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}

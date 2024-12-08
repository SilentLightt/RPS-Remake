using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject[] menuPanels;       // Array of menu panels (Main Menu, Settings, etc.)
    private string SceneName;

    //private const string DifficultyKey = "GameDifficulty";

    //public TMP_Dropdown difficultyDropdown; // Dropdown for selecting difficulty

    //public Slider masterVolumeSlider;   // Slider for Master Volume
    //public Slider musicVolumeSlider;    // Slider for Music Volume
    //public Slider sfxVolumeSlider;      // Slider for SFX Volume

    //private const string MasterVolumeKey = "MasterVolume";
    //private const string MusicVolumeKey = "MusicVolume";
    //private const string SFXVolumeKey = "SFXVolume";
    //private const string ResolutionKey = "Resolution";
    //private const string WindowModeKey = "WindowMode";
    //private const string GraphicsQualityKey = "GraphicsQuality";

    //private Resolution[] resolutions;
    //private int currentResolutionIndex;
    //private bool isFullScreen;
    //private int currentGraphicsQuality;
    //public AudioSource musicSource;    // AudioSource for music
    //public AudioSource sfxSource;      // AudioSource for sound effects

    private int currentPanelIndex = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        // Load saved settings
        //LoadSettings();
        // Display the first panel (Main Menu by default)
        ShowPanel(0);
        
        //SetDropdownValue(PlayerPrefs.GetString(DifficultyKey, "Medium"));

        //if (sfxSource.isPlaying)
        //{
        //    Debug.Log("SFX is playing at the start.");
        //}

    }
    //public void SetDifficulty(int index)
    //{
    //    string difficulty = difficultyDropdown.options[index].text;
    //    PlayerPrefs.SetString(DifficultyKey, difficulty);
    //    PlayerPrefs.Save();
    //    Debug.Log("Game difficulty set to: " + difficulty);
    //}
    //private void SetDropdownValue(string difficulty)
    //{
    //    int index = difficultyDropdown.options.FindIndex(option => option.text == difficulty);
    //    if (index >= 0)
    //    {
    //        difficultyDropdown.value = index;
    //    }
    //}

    //public void SetMasterVolume(float volume)
    //{
    //    AudioListener.volume = volume;  // Master volume affects all audio sources
    //    PlayerPrefs.SetFloat(MasterVolumeKey, volume);
    //    PlayerPrefs.Save();

    //    Debug.Log("Master volume set to: " + volume);
    //    //if (SoundManager.instance != null)
    //    //{
    //    //    SoundManager.instance.SetMusicVolume(volume);
    //    //}
    //    //PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    //    //PlayerPrefs.Save();
    //}

    //public void SetMusicVolume(float volume)
    //{
    //    //if (SoundManager.instance != null)
    //    //{
    //    //    SoundManager.instance.SetMusicVolume(volume);
    //    //}
    //    //PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    //    //PlayerPrefs.Save();
    //    if (musicSource != null)
    //    {
    //        musicSource.volume = volume;
    //    }
    //    PlayerPrefs.SetFloat(MusicVolumeKey, volume);
    //    PlayerPrefs.Save();

    //    //Debug.Log("Music volume set to: " + volume);
    //}

    //public void SetSFXVolume(float volume)
    //{
    //    //if (SoundManager.instance != null)
    //    //{
    //    //    SoundManager.instance.SetSFXVolume(volume);
    //    //}
    //    //PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    //    //PlayerPrefs.Save();
    //    if (sfxSource != null)
    //    {
    //        sfxSource.volume = volume;
    //    }
    //    PlayerPrefs.SetFloat(SFXVolumeKey, volume);
    //    PlayerPrefs.Save();

    //    Debug.Log("SFX volume set to: " + volume);
    //}

    public void ShowPanel(int panelIndex)
    {
        //if (sfxSource != null)
        //{
        //    sfxSource.Play();
        //}
        // Hide all panels
        foreach (var panel in menuPanels)
        {
            panel.SetActive(false);
        }

        // Show the selected panel
        menuPanels[panelIndex].SetActive(true);
        currentPanelIndex = panelIndex;
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
  

    public void BackButton()
    {
        //if (sfxSource != null)
        //{
        //    sfxSource.Play();
        //}
        // Return to the previous menu panel, or stay on the first one if already there
        int previousPanelIndex = Mathf.Max(currentPanelIndex - 1, 0);
        ShowPanel(previousPanelIndex);
    }

    //public void DefaultButton()
    //{
    //    if (sfxSource != null)
    //    {
    //        sfxSource.Play();
    //    }
    //    // Reset settings to default values
    //    SetDropdownValue("Medium");
    //    SetDifficulty(difficultyDropdown.value);

    //    SetMasterVolume(0.2f);
    //    masterVolumeSlider.value = 0.2f;  // Reset slider to maximum

    //    SetMusicVolume(0.2f);
    //    musicVolumeSlider.value = 0.2f;  // Reset slider to maximum

    //    SetSFXVolume(0.2f);
    //    sfxVolumeSlider.value = 0.2f;
    //    Debug.Log("Settings reset to default.");
    //}

    //public void SaveButton()
    //{
    //    if (sfxSource != null)
    //    {
    //        sfxSource.Play();
    //    }
    //    // Save any additional settings if needed
    //    PlayerPrefs.Save();
    //    Debug.Log("Settings saved.");
    //}

    //private void LoadSettings()
    //{
    //    // Load saved difficulty setting, defaulting to "Medium" if not set
    //    string savedDifficulty = PlayerPrefs.GetString(DifficultyKey, "Medium");
    //    Debug.Log("Loaded difficulty: " + savedDifficulty);

    //    // Load saved Master Volume setting, defaulting to 1 (max volume) if not set
    //    float savedMasterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);
    //    masterVolumeSlider.value = savedMasterVolume;
    //    SetMasterVolume(savedMasterVolume);

    //    // Load saved Music Volume setting, defaulting to 1 (max volume) if not set
    //    float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.5f);
    //    musicVolumeSlider.value = savedMusicVolume;
    //    SetMusicVolume(savedMusicVolume);

    //    // Load saved SFX Volume setting, defaulting to 1 (max volume) if not set
    //    float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.5f);
    //    sfxVolumeSlider.value = savedSFXVolume;
    //    SetSFXVolume(savedSFXVolume);
    //}
    //public void AssignAudioSources(AudioSource music, AudioSource sfx)
    //{
    //    musicSource = music;
    //    sfxSource = sfx;
    //}
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}

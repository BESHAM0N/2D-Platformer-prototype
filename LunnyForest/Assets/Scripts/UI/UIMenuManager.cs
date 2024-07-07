using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private Button _settingsMenuButton;
    [SerializeField] private Button _exitSettingsMenuButton;
    [SerializeField] private Button _openChallengesButton;
    [SerializeField] private Button _exitChallengesButton;
    [SerializeField] private Button _openShopButton;
    [SerializeField] private Button _levelOneButton;
    [SerializeField] private Button _levelTwoButton;
    
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _challengesMenu;

    private void Start()
    {
        _settingsMenuButton.onClick.AddListener(OpenSettingsMenu);
        _exitSettingsMenuButton.onClick.AddListener(CloseSettingsMenu);
        _openChallengesButton.onClick.AddListener(OpenChallengesMenu);
        _exitChallengesButton.onClick.AddListener(CloseChallengesMenu);
        _levelOneButton.onClick.AddListener(ToLevelOveScene);
    }

    private void OpenSettingsMenu()
    {
        _settingsMenu.gameObject.SetActive(true);
    }

    private void CloseSettingsMenu()
    {
        _settingsMenu.gameObject.SetActive(false);
    }

    private void OpenChallengesMenu()
    {
        _challengesMenu.gameObject.SetActive(true);
    }
    
    private void CloseChallengesMenu()
    {
        _challengesMenu.gameObject.SetActive(false);
    }

    private void ToLevelOveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager_Endless : MonoBehaviour
{

    [SerializeField] private Scrollbar _progressBar;
    [SerializeField] private GameManager_Endless _gm;
    [SerializeField] private GameObject _gameOverPanel, _gameWonPanel, _pausePanel, _optionPanel, _tutorialPanel;
    [SerializeField] private float _progressBarSpeed = 10f;

    private bool _gameWonScreenShown = false;
    private float _currentProgress = 0f;    

    void Awake()
    {
        _gm = FindObjectOfType<GameManager_Endless>();
        if (_gm == null)
        {
            Debug.LogError("GameManager Script is Null!");
        }
    }

    void Start()
    {
        _progressBar.size = 0f;
        _tutorialPanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        _gameWonPanel.SetActive(false);
        _pausePanel.SetActive(false);
        _optionPanel.SetActive(false);
    }

    void Update()
    {
        progressBarLerp();
    }

    void progressBarLerp()
    {
        if (_gm == null) return;
        float progress = Mathf.Clamp01(_gm.GetElapsedTime() / _gm.GameDuration());
        _currentProgress = Mathf.Lerp(_currentProgress, progress, Time.deltaTime * _progressBarSpeed);
        _progressBar.size = _currentProgress;
    }
    void stopPlayingLoopingSFX()
    {
        AudioManager.instance.loopingSfxSourceA.Stop();
        AudioManager.instance.loopingSfxSourceB.Stop();
    }

    public void showGameOverScreen()
    {

        stopPlayingLoopingSFX();
        AudioManager.instance.PlaySfx("GameFailed");
        _gameOverPanel.SetActive(true);
    }
    
    public void showGameWonScreen()
    {
        if (_gameWonScreenShown) return; // Prevents multiple calls
        _gameWonScreenShown = true;

        stopPlayingLoopingSFX();
        AudioManager.instance.PlaySfx("GameWon");
        _gameWonPanel.SetActive(true);
    }
    
    public void showPauseScreen()
    {
        _pausePanel.SetActive(true);
    }
    public void hidePauseScreen()
    {
        _pausePanel.SetActive(false);
    }
    public void showOptionPanel()
    {
        _optionPanel.SetActive(true);
    }

    public void closeTutorialPanel()
    {
        _tutorialPanel.SetActive(false);
    }

    public void loadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void GoToEpilogueScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Eplg_EndlessRunner");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager_Platformer : MonoBehaviour
{
    [SerializeField] private PlayerController _player; // Assign in Unity Inspector
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Scrollbar _progressBarScrollBar;

    private bool _gameWon = false;

    private int currentLevelIndex; // Track the current level index

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameWonScreen;
    [SerializeField] private GameObject gameOverScreen;

    private CompletedChapter_Chapter4 _completedChapter; // Reference to CompletedChapter script

    void Awake()
    {
        _completedChapter = FindObjectOfType<CompletedChapter_Chapter4>(); // Find CompletedChapter in the scene

        if (_player == null) Debug.LogError("PlayerController reference is missing!");
        if (_completedChapter == null) Debug.LogError("CompletedChapter Script is Null!");

        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        resetGameState();
    }

    void Update()
    {
        if (Time.timeScale == 0f || _gameWon) return;

        if (_player.FinishBoxTrigger())
        {
           _completedChapter.UnlockChapter4Verse(); // Unlock Chapter 4 Verse through CompletedChapter
            endGame(false);
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        hideUI();
        ShowPauseScreen();
        Debug.Log("Game paused!");
    }

    public void resumeGame()
    {
        HidePauseScreen();
        Time.timeScale = 1f;
        showUI();
        Debug.Log("Game resumed!");
    }

    public void endGame(bool isFail)
    {
        if (_gameWon) return;

        _gameWon = true;
        Time.timeScale = 0f;
        hideUI();

        if (isFail)
        {
            ShowGameOverScreen();
            Debug.Log("Game Over!");
        }
        else
        {
            ShowGameWonScreen();
            UnlockChapter4Verse(); // Ensure unlock happens on Game Won screen
            Debug.Log("Victory! Chapter 4 Verse unlocked!");
        }
    }

    void UnlockChapter4Verse()
    {
        if (_completedChapter != null)
        {
            Debug.Log("Calling CompletedChapter script to unlock Chapter 4 Verse...");
            _completedChapter.UnlockNewChapterVerse(4); // Calls CompletedChapter to save progress
        }
        else
        {
            Debug.LogError("CompletedChapter script not found!");
        }
    }

    void resetGameState()
    {
        _gameWon = false;
        Time.timeScale = 1f;
        Debug.Log("Game state reset!");
    }

    // UI Methods (Integrated from UIManagerPlatformer)
    void ShowPauseScreen()
    {
        if (pauseScreen != null) pauseScreen.SetActive(true);
    }

    void HidePauseScreen()
    {
        if (pauseScreen != null) pauseScreen.SetActive(false);
    }

    void ShowGameWonScreen()
    {
        if (gameWonScreen != null) gameWonScreen.SetActive(true);
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null) gameOverScreen.SetActive(true);
    }
    void hideUI()
    {
        if (_pauseBtn != null) _pauseBtn.gameObject.SetActive(false);
        if (_progressBarScrollBar != null) _progressBarScrollBar.gameObject.SetActive(false);
    }

    void showUI()
    {
        if (_pauseBtn != null) _pauseBtn.gameObject.SetActive(true);
        if (_progressBarScrollBar != null) _progressBarScrollBar.gameObject.SetActive(true);
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Fb_GameManager : MonoBehaviour
{   
    public Leaderboard leaderboardReference;
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;

    public TMP_Text pointsText;
    public float points = 0;
    public TMP_Text TimerFont;
    public float TimeValue = 91;

    [SerializeField] private Button PauseButton;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject StartHelpMenu;

    public bool isReady; //if true make player move

    private CompletedChapter3 _completedChapter; // Reference to the Chapter 3 script

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic("Jesus_BG");
        isReady = false;
        pointsText.text = points.ToString();
        TimerFont.text = TimeValue.ToString();
        StartHelpMenu.SetActive(true);
        Time.timeScale = 0;

        // Initialize CompletedChapter_Chapter3 reference
        _completedChapter = FindObjectOfType<CompletedChapter3>();

        if (_completedChapter == null)
        {
            Debug.LogError("CompletedChapter3 script is missing in the scene!");
        }
        else
        {
            Debug.Log("CompletedChapter3 initialized successfully.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeValue <= 0)
        {
            TimeValue = 0;
            LoseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if (StartHelpMenu.activeSelf || WinScreen.activeSelf || LoseScreen.activeSelf)
        {
            PauseButton.enabled = false;
        }
        else
        {
            PauseButton.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
        }
    }

    public void Fb_AddPoints()
    {
        points++;
        pointsText.text = points.ToString();
        if (points == 30)
        {   
            Leaderboard.Instance.tallyScores(Mathf.RoundToInt(points));
            Time.timeScale = 0;
            WinScreen.SetActive(true);

            // Unlock Chapter 3 Verse
            if (_completedChapter != null)
            {
                _completedChapter.UnlockNewChapterVerse(3); // Unlock Chapter 3
                Debug.Log("Chapter 3 verse unlocked.");
            }
            else
            {
                Debug.LogError("Failed to unlock Chapter 3. CompletedChapter_Chapter3 script is null.");
            }
        }
    }

    public void TimeDecay()
    {
        TimeValue--;
        TimerFont.text = TimeValue.ToString();
    }

    public void FbUI_PauseTime()
    {
        isReady = false;
        Time.timeScale = 0;
    }
    public void FbUI_ResumeTime()
    {
        isReady = true;
        Time.timeScale = 1;
    }

    // From Matching Game Codes to this file
    public void RetryGameLevel()
    {
        Time.timeScale = 1;
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isReady = false;
        Debug.Log("Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isReady = true;
        Debug.Log("GameResume");
    }

    public void GoToEpilogue_FallingItemScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Eplg_FallingItem", LoadSceneMode.Additive);
    }
}
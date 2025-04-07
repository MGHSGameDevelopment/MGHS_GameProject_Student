using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_Endless : MonoBehaviour
{
    [SerializeField] private float _defaultSpeed = 5f; // Default speed for obstacles
    [SerializeField] private float _speedIncrease = 2f; // Added speed value for difficulty scaling
    [SerializeField] private float _speedIncreaseInterval = 5f; // First increased speed happens after 5 seconds
    [SerializeField] private float _gameDuration = 30f; // Game duration

    [SerializeField] Button _pauseBtn;
    [SerializeField] Scrollbar _progressBarScrollBar;

    private bool _gameWon = false;

    private float _nextIncreaseTime;
    private float _runtimeSpeed;
    private float _elapsedTime = 0f;

    private UIManager_Endless _UI;

    private ParallaxBG[] _BGs;
    void Awake()
    {
        _UI = FindObjectOfType<UIManager_Endless>();
        _BGs = FindObjectsOfType<ParallaxBG>();
        if (_UI == null)
        {
            Debug.LogError("UIManager Script is Null!");
        }
        if (_BGs.Length == 0)
        {
            Debug.LogError("No ParallaxBG Found!");
        }
    }

    void Start()
    {

        resetGameState();

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic("Moses_BG");
        }
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;

        _elapsedTime += Time.deltaTime;

        if (_elapsedTime <= _gameDuration)
        {
            scaleDifficulty();
        }
        else
        {
            endGame(0);
        }
    }

    void scaleDifficulty()
    {
        if (_elapsedTime >= _nextIncreaseTime)
        {
            _runtimeSpeed += _speedIncrease;
            _nextIncreaseTime += _speedIncreaseInterval;

            foreach (ParallaxBG bg in _BGs)
            {
                float newSpeed = bg.GetSpeed() + bg.GetSpeedMultiplier();
                bg.SetSpeed(newSpeed);
            }

            Debug.Log("Difficulty Increased!");
        }

        Debug.Log("Runtime Speed is = " + _runtimeSpeed);
    }

    void hideUI()
    {
        _pauseBtn.gameObject.SetActive(false);
        _progressBarScrollBar.gameObject.SetActive(false);
    }

    void showUI()
    {
        _pauseBtn.gameObject.SetActive(true);
        _progressBarScrollBar.gameObject.SetActive(true);
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        AudioManager.instance.PauseLoopingSfx();
        hideUI();
        _UI.showPauseScreen();
    }

    public void resumeGame()
    {
        _UI.hidePauseScreen();
        Time.timeScale = 1f;
        AudioManager.instance.ResumeLoopingSfx();
        showUI();
    }

    //Pass 1 to show game over, 0 to show game won
    public void endGame(int isFail)
    {

        if (_gameWon) return; // Prevents multiple calls
        _gameWon = true;

        Time.timeScale = 0f;
        hideUI();

        if (isFail == 1)
        {
            _UI.showGameOverScreen();
        }

        if (isFail == 0)
        {
            _UI.showGameWonScreen();
        }
        Debug.Log("Game Over");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        _UI.closeTutorialPanel();
        showUI();
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayLoopingSfxB("Sea");
        }
    }

    public float GameDuration()
    {
        return _gameDuration;
    }

    public float AdjustedSpeed()
    {
        return _runtimeSpeed;
    }

    public float GetElapsedTime()
    {
        return _elapsedTime;
    }

    public bool getGameWon()
    {
        return _gameWon;
    }

    void resetGameState()
    {
        _elapsedTime = 0f;
        _runtimeSpeed = _defaultSpeed;
        _nextIncreaseTime = _speedIncreaseInterval;

        Time.timeScale = 0f;

        foreach (ParallaxBG bg in _BGs)
        {
            bg.SetSpeed(bg.GetDefaultSpeed());
        }
    }

}
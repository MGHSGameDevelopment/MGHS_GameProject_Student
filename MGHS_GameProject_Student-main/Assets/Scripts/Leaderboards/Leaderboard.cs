using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public int totalScore = 0;

    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "cd8384d100c1f8957ec00fddccb2c50ab52f03caad7387d24a1745288f9f7e6b";

    public static Leaderboard Instance;

    void Awake()
    {
        // If an instance already exists, we don't need to create a new one.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensures that the object persists across scene changes
            Debug.Log("Leaderboard instance created and set");
        }
    }

    void Start()
    {
        if (Instance != this) return; // Prevents the Start method from running on duplicate instances
        
        // Get the leaderboard when the scene starts
        GetLeaderboard();
    }

    public void tallyScores(int score)
    {
        totalScore += score;
        Debug.Log("Tallying score " + score + ", New Total: " + totalScore);
    }

    // This method is called to fetch the leaderboard data
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, (msg) =>
        {
            int loopLength = Mathf.Min(msg.Length, names.Count);
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        });
    }

    // This method uploads a new score entry to the leaderboard
    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, (msg) =>
        {
            // After uploading, fetch the updated leaderboard
            GetLeaderboard();
        });
    }
}

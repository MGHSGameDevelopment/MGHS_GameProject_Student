using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Dan.Main;
using System.Collections;

public class ScoreManager : MonoBehaviour
{   

    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;
    IEnumerator Start()
    {   
        yield return new WaitForSeconds(0.2f); 
        if (Leaderboard.Instance != null)
            {
                Debug.Log("Leaderboard is still valid.");
            }
        else
            {
                Debug.LogError("Leaderboard instance is lost after scene change.");
            }
        if (Leaderboard.Instance == null)
        {
            Debug.LogError("Leaderboard instance not found!");
            yield break;
        }

        int score = Leaderboard.Instance.totalScore;
        inputScore.text = score.ToString();
    }
    public void SubmitScore()
    {   
        Debug.Log("SubmitScore called with Name: " + inputName.text + " and Score: " + inputScore.text);
        
        if (Leaderboard.Instance == null)
        {
            Debug.LogError("Leaderboard instance is not available after scene change!");
            return;
        }
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
    
}

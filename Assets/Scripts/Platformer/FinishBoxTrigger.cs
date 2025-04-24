using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBoxTrigger : MonoBehaviour
{   
    public CompletedChapter_Chapter4 chapterUnlocker;
    public Leaderboard leaderboardReference;
    [SerializeField] GameObject victoryPanelBoard; // Assign in Unity Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            victoryPanelBoard.SetActive(true); // Show the VictoryPanelBoard
            Leaderboard.Instance.tallyScores(5);
            chapterUnlocker.UnlockNewChapterVerse(4);
            Debug.Log("Player entered the finish box!");

            // Call the PlayerController method to mark the player as having reached the goal
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {   
                chapterUnlocker.UnlockNewChapterVerse(4);
                player.TriggerFinish(); // Notify player that they've finished
            }
        }
    }
}
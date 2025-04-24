using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBoxTrigger : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanelBoard; // Assign in Unity Inspector
    [SerializeField] private CompletedChapter_Chapter4 _completedChapter; // Reference to CompletedChapter script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            victoryPanelBoard.SetActive(true); // Show the VictoryPanelBoard
            Debug.Log("Player entered the finish box!");

            UnlockChapter4Verse(); // Unlock Chapter 4 Verse upon entering the finish box
        }
    }

    void UnlockChapter4Verse()
    {
        if (_completedChapter != null)
        {
            Debug.Log("Calling CompletedChapter_Chapter4 script to unlock Chapter 4 Verse...");
            _completedChapter.UnlockNewChapterVerse(4); // Calls CompletedChapter to save progress
        }
        else
        {
            Debug.LogError("CompletedChapter_Chapter4 script not found!");
        }
    }
}
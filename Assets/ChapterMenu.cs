using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterMenu : MonoBehaviour
{
    public Button[] ChapterButtons; // Buttons for chapters
    public Button[] VerseButtons;   // Buttons for verses, corresponding to chapters

    private void Awake()
    {
        Debug.Log("ChapterMenu Awake called.");
        Debug.Log($"UnlockedChapter = {PlayerPrefs.GetInt("UnlockedChapter", 1)}");

        // Ensure Chapter 1 is always unlocked
        if (PlayerPrefs.GetInt("UnlockedChapter", 1) < 1)
        {
            PlayerPrefs.SetInt("UnlockedChapter", 1); // Ensure chapter 1 is unlocked
            PlayerPrefs.SetInt("ChapterCompleted_1", 1); // Ensure chapter 1's verse is marked as completed
            PlayerPrefs.Save();
            Debug.Log("Chapter 1 is unlocked by default.");
        }

        UpdateButtons(); // Initialize buttons based on progress
    }

    public void UpdateButtons()
    {
        Debug.Log("Updating Chapter and Verse Buttons...");

        for (int i = 0; i < ChapterButtons.Length; i++)
        {
            bool isChapterCompleted = PlayerPrefs.GetInt($"ChapterCompleted_{i + 1}", 0) == 1;

            Debug.Log($"ChapterCompleted_{i + 1} = {PlayerPrefs.GetInt($"ChapterCompleted_{i + 1}", 0)}");

            // Update Chapter Buttons (Chapter 1 always enabled)
            if (ChapterButtons[i] != null)
            {
                ChapterButtons[i].enabled = true;
                ChapterButtons[i].interactable = true;
                Debug.Log($"ChapterButton {i + 1} is always enabled.");
            }

            // Update Verse Buttons based on completion status
            if (VerseButtons[i] != null)
            {
                if (i == 0 || isChapterCompleted) // Always unlock Chapter 1 and completed chapters
                {
                    VerseButtons[i].enabled = true;
                    VerseButtons[i].interactable = true;
                    Debug.Log($"VerseButton for Chapter {i + 1} unlocked.");
                }
                else
                {
                    VerseButtons[i].enabled = false;
                    VerseButtons[i].interactable = false;
                    Debug.Log($"VerseButton for Chapter {i + 1} locked.");
                }
            }
        }
    }
}
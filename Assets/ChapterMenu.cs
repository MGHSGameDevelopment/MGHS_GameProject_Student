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
        // Retrieve the unlocked chapter value from PlayerPrefs (default is 1)
        int unlockedChapter = PlayerPrefs.GetInt("UnlockedChapter", 1);
        Debug.Log($"UnlockedChapter from PlayerPrefs: {unlockedChapter}");

        // Disable all chapter buttons initially
        for (int i = 0; i < ChapterButtons.Length; i++)
        {
            if (ChapterButtons[i] != null)
            {
                ChapterButtons[i].enabled = false;
                ChapterButtons[i].interactable = false;
                Debug.Log($"ChapterButton {i} disabled.");
            }
            else
            {
                Debug.LogWarning($"ChapterButton {i} is not assigned in the Inspector!");
            }
        }

        // Disable all verse buttons initially
        for (int i = 0; i < VerseButtons.Length; i++)
        {
            if (VerseButtons[i] != null)
            {
                VerseButtons[i].enabled = false;
                VerseButtons[i].interactable = false;
                Debug.Log($"VerseButton {i} disabled.");
            }
            else
            {
                Debug.LogWarning($"VerseButton {i} is not assigned in the Inspector!");
            }
        }

        // Enable and make interactable unlocked chapters and their corresponding verses
        for (int i = 0; i < unlockedChapter; i++)
        {
            if (i < ChapterButtons.Length && ChapterButtons[i] != null)
            {
                ChapterButtons[i].enabled = true;
                ChapterButtons[i].interactable = true;
                Debug.Log($"ChapterButton {i} enabled.");
            }

            if (i < VerseButtons.Length && VerseButtons[i] != null)
            {
                VerseButtons[i].enabled = true;
                VerseButtons[i].interactable = true;
                Debug.Log($"VerseButton {i} enabled.");
            }
        }
    }
}
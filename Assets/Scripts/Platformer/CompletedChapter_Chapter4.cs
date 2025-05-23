using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedChapter_Chapter4 : MonoBehaviour
{
    public void UnlockNewChapterVerse(int chapterNumber)
    {
        Debug.Log($"UnlockNewChapterVerse triggered for Chapter {chapterNumber}.");

        // Only unlock Chapter 4 (hardcoded logic to restrict unlocking)
        if (chapterNumber == 4)
        {
            PlayerPrefs.SetInt($"ChapterCompleted_{chapterNumber}", 1); // Mark Chapter 4 as completed
            Debug.Log($"ChapterCompleted_{chapterNumber} = {PlayerPrefs.GetInt($"ChapterCompleted_{chapterNumber}", 0)}");
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs saved successfully for Chapter 4.");
        }
        else
        {
            Debug.LogWarning($"UnlockNewChapterVerse called for Chapter {chapterNumber}, but only Chapter 4 is allowed to be unlocked.");
        }
    }

    public void UnlockChapter4Verse()
    {
        UnlockNewChapterVerse(4); // Reuse existing logic
    }
}


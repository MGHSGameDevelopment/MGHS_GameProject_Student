using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedChapter3 : MonoBehaviour
{
    public void UnlockNewChapterVerse(int chapterNumber)
    {
        Debug.Log($"UnlockNewChapterVerse triggered for Chapter {chapterNumber}.");

        // Only unlock Chapter 3 (hardcoded logic to restrict unlocking)
        if (chapterNumber == 3)
        {
            PlayerPrefs.SetInt($"ChapterCompleted_{chapterNumber}", 1); // Mark Chapter 2 as completed
            Debug.Log($"ChapterCompleted_{chapterNumber} = {PlayerPrefs.GetInt($"ChapterCompleted_{chapterNumber}", 0)}");
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs saved successfully for Chapter 3.");
        }
        else
        {
            Debug.LogWarning($"UnlockNewChapterVerse called for Chapter {chapterNumber}, but only Chapter 2 is allowed to be unlocked.");
        }
    }
}

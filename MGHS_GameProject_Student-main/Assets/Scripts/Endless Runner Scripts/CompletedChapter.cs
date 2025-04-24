using UnityEngine;

public class CompletedChapter : MonoBehaviour
{
public void UnlockNewChapterVerse(int chapterNumber)
{
    Debug.Log($"UnlockNewChapterVerse triggered for Chapter {chapterNumber}.");

    // Only unlock Chapter 2 (hardcoded logic to restrict unlocking)
    if (chapterNumber == 2)
    {
        PlayerPrefs.SetInt($"ChapterCompleted_{chapterNumber}", 1); // Mark Chapter 2 as completed
        Debug.Log($"ChapterCompleted_{chapterNumber} = {PlayerPrefs.GetInt($"ChapterCompleted_{chapterNumber}", 0)}");
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs saved successfully for Chapter 2.");
    }
    else
    {
        Debug.LogWarning($"UnlockNewChapterVerse called for Chapter {chapterNumber}, but only Chapter 2 is allowed to be unlocked.");
    }
}
}


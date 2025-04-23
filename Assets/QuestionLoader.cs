using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;
}

[System.Serializable]
public class QuestionList
{
    public Question[] questions;
}

public class QuestionLoader : MonoBehaviour
{
    public static Question[] LoadQuestions(string fileName)
    {
        TextAsset file = Resources.Load<TextAsset>(fileName);

        if (file == null)
        {
            Debug.LogError("File not found: " + fileName);
            return new Question[0];
        }

        QuestionList list = JsonUtility.FromJson<QuestionList>("{\"questions\":" + file.text + "}");
        return list.questions;
    }
}

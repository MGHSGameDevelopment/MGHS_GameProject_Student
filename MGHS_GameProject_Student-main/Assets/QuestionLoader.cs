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
    public static Question[] LoadQuestions(string quizSet1)
    {
        TextAsset file = Resources.Load<TextAsset>(quizSet1);

        if (file == null)
        {
            Debug.LogError("File not found: " + quizSet1);
            return new Question[0];
        }

        QuestionList list = JsonUtility.FromJson<QuestionList>("{\"questions\":" + file.text + "}");
        return list.questions;
    }
}

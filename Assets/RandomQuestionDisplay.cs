using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


public class RandomQuestionDisplay : MonoBehaviour
{
    public Question[] quizSet1;
    public Question[] quizSet2;
    public Question[] quizSet3;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI summaryScoreText;
    public TextMeshProUGUI progressText;
    public Button[] answerButtons;
    public GameObject summaryPanel; // Panel to display after quiz ends

    private Question[] currentQuestions;
    private List<int> unusedIndices = new List<int>();
    private int currentQuestionIndex = -1;
    private int score = 0;
    private int totalQuestions = 0;
    private int questionsAnswered = 0;

    void Start()
    {
        // Wait for user to select quiz set via button
        UpdateScoreUI();
        UpdateProgressUI();

        if (summaryPanel != null)
            summaryPanel.SetActive(false);
    }

    public void SelectQuizSet(int setNumber)
    {
        string fileName = setNumber switch
        {
            1 => "quizSet1",
            2 => "quizSet2",
            3 => "quizSet3",
            _ => null
        };

        if (fileName == null)
        {
            Debug.LogWarning("Invalid quiz set number.");
            return;
        }

        currentQuestions = QuestionLoader.LoadQuestions(fileName);

        score = 0;
        questionsAnswered = 0;
        totalQuestions = currentQuestions.Length;

        UpdateScoreUI();
        UpdateProgressUI();
        ResetQuestionPool();
        ShowRandomQuestion();
    }

    public void ShowRandomQuestion()
    {
        if (currentQuestions == null || currentQuestions.Length == 0 || questionText == null) return;

        if (unusedIndices.Count == 0)
        {
            foreach (Button btn in answerButtons)
            {
                btn.gameObject.SetActive(false);
            }

            if (summaryScoreText != null)
                summaryScoreText.text = "Final Score: " + score + "/" + totalQuestions;

            if (summaryPanel != null)
                summaryPanel.SetActive(true);

            return;
        }

        int randomListIndex = Random.Range(0, unusedIndices.Count);
        currentQuestionIndex = unusedIndices[randomListIndex];
        unusedIndices.RemoveAt(randomListIndex);

        DisplayCurrentQuestion();
    }

    void DisplayCurrentQuestion()
    {
        Question q = currentQuestions[currentQuestionIndex];
        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int choiceIndex = i;
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() =>
            {
                if (choiceIndex == currentQuestions[currentQuestionIndex].correctAnswerIndex)
                {
                    score++;
                    UpdateScoreUI();
                }

                questionsAnswered++;
                UpdateProgressUI();
                ShowRandomQuestion();
            });
        }
    }

    void ResetQuestionPool()
    {
        unusedIndices.Clear();
        for (int i = 0; i < currentQuestions.Length; i++)
        {
            unusedIndices.Add(i);
        }

        currentQuestionIndex = -1;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    void UpdateProgressUI()
    {
        if (progressText != null && totalQuestions > 0)
            progressText.text = questionsAnswered.ToString() + "/" + totalQuestions.ToString();
    }
}

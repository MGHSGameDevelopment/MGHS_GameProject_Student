using UnityEngine;

public class RandomQuestion : MonoBehaviour
{
    public GameObject[] chap1Questions;
    private GameObject currentQuestions;
    private int lastIndex = -1;

    public void ShowRandomquestion1()
    {
        if (chap1Questions.Length == 0) return;

        // Deactivate current question
        if (currentQuestions != null)
        {
            currentQuestions.SetActive(false);
        }

        int randomIndex;

        do //activate random question
        {
            randomIndex = Random.Range(0, chap1Questions.Length);
        } while (chap1Questions.Length > 1 && randomIndex == lastIndex);

        lastIndex = randomIndex;

        currentQuestions = chap1Questions[randomIndex];
        currentQuestions.SetActive(true);
    }




    public GameObject[] chap2Questions;

    public void ShowRandomquestion2()
    {
        if (chap2Questions.Length == 0) return;

        
        if (currentQuestions != null)
        {
            currentQuestions.SetActive(false);
        }

        int randomIndex;

        do 
        {
            randomIndex = Random.Range(0, chap2Questions.Length);
        } while (chap2Questions.Length > 1 && randomIndex == lastIndex);

        lastIndex = randomIndex;

        currentQuestions = chap2Questions[randomIndex];
        currentQuestions.SetActive(true);
    }


    public GameObject[] chap3Questions;

    public void ShowRandomquestion3()
    {
        if (chap3Questions.Length == 0) return;


        if (currentQuestions != null)
        {
            currentQuestions.SetActive(false);
        }

        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, chap3Questions.Length);
        } while (chap3Questions.Length > 1 && randomIndex == lastIndex);

        lastIndex = randomIndex;

        currentQuestions = chap3Questions[randomIndex];
        currentQuestions.SetActive(true);
    }


}

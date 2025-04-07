using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
public class GotoChapterScene : MonoBehaviour
{
    public bool Chapter1Enabled;
    [SerializeField] private GameObject Chapter1UI;
    public bool Chapter2Enabled;
    [SerializeField] private GameObject Chapter2UI;
    public bool Chapter3Enabled;
    [SerializeField] private GameObject Chapter3UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Chapter1UI.activeSelf)
        {
            Chapter1Enabled = true;
        }
        else
            Chapter1Enabled = false;

        if (Chapter2UI.activeSelf)
        {
            Chapter2Enabled = true;
        }
        else
            Chapter2Enabled = false;

        if (Chapter3UI.activeSelf)
        {
            Chapter3Enabled = true;
        }
        else
            Chapter3Enabled = false;
    }

    public void LoadActiveChapter()
    {
        LoadChapter1();
        LoadChapter2();
        LoadChapter3();
    }

    void LoadChapter1()
    {
        if (Chapter1Enabled)
        {

            SceneManager.LoadScene("Prlg_MatchingGame");
            Debug.Log("Loading Chapter 1");
        }
    }

    void LoadChapter2()
    {
        if (Chapter2Enabled)
        {
            SceneManager.LoadScene("Prlg_EndlessRunner");
            Debug.Log("Loading Chapter 2");
        }
    }

    void LoadChapter3()
    {
        if (Chapter3Enabled)
        {
            SceneManager.LoadScene("Prlg_FallingItem");
            Debug.Log("Loading Chapter 3");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    //Not much time, we don't have time to add run text dialogue shit, just enable the gameObjects shit for now and we'll add that feature later
    [Header("Opening Cutscene Gameobjects")]
    [SerializeField] private PlayAnimation ChapterStartOpening; //Fades from black to transparent (3 seconds)
    [SerializeField] private PlayAnimation UIButtonFade; //After 3 Seconds (play this animation)
    [SerializeField] private PlayAnimation DialogueStartOpening; //After 3 Seconds (play this animation)
    [SerializeField] private bool CanScroll;
    bool FirstClicked;

    [Header("Arrows")]
    [SerializeField] private Button LeftArrow;
    [SerializeField] private Button RightArrow;
    [SerializeField] private GameObject GotoGameScene;

    [Header("==============================================")]
    [SerializeField] private GameObject[] Sequence;
    [SerializeField] private int IndexCount = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        ChapterStartOpening.GetComponent<PlayAnimation>();
        UIButtonFade.GetComponent<PlayAnimation>();
        DialogueStartOpening.GetComponent<PlayAnimation>();
    }

    void Start()
    {
        LeftArrow.interactable = false;
        RightArrow.interactable = false;
        FirstClicked = false;

        UpdateSequenceVisibility();
    }

    // Update is called once per frame
    void Update()
    {
     if (ChapterStartOpening.hasPlayed && UIButtonFade.hasPlayed && DialogueStartOpening.hasPlayed)
        {
            LeftArrow.interactable = true;
            RightArrow.interactable = true;
            CanScroll = true;
        }
       /* if (Sequence[0].activeSelf == true)
        {
            LeftArrow.enabled = false;
        }
        if (Sequence[Sequence.Length].activeSelf == true)
        {
            RightArrow.enabled = false;
        }*/

        UpdateArrowVisibility();

        if (Sequence[Sequence.Length-1].activeSelf == true)
        {
            GotoGameScene.SetActive(true);
        }
        else
        {
            GotoGameScene.SetActive(false);
        }
    }

    //This is temporary, will be replaced by running text dialogue script later
    public void ScrollThrough()
    {
        if (CanScroll)
        {
            IndexCount++;
            if (IndexCount >= Sequence.Length)
            {
                IndexCount = Sequence.Length - 1; // Clamp to the last index
            }
            UpdateSequenceVisibility();
        }
    }

    public void ScrollBackward()
    {
        if (CanScroll)
        {
            IndexCount--;
            if (IndexCount < 0)
            {
                IndexCount = 0; // Clamp to the first index
            }
            UpdateSequenceVisibility();
        }
    }

    private void UpdateSequenceVisibility()
    {
        for (int i = 0; i < Sequence.Length; i++)
        {
            Sequence[i].SetActive(i == IndexCount);
        }
    }

    private void UpdateArrowVisibility()
    {
        LeftArrow.interactable = IndexCount > 0;
        RightArrow.interactable = IndexCount < Sequence.Length - 1;
    }

    public void CheckFirstClick()
    {
        FirstClicked = true;
        UpdateSequenceVisibility();
        if (FirstClicked) ScrollThrough();
    }

    
    
    
    public void GotoMatchingGame()
    {
        SceneManager.LoadScene("MatchingGame");
    }

    public void GotoEndlessRunner()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void GotoFallingItem()
    {
        SceneManager.LoadScene("FallingItem");
    }


    public void Goto_GameMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

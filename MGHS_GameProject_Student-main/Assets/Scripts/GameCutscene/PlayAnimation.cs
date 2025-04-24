using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    Animator animator;
    public bool hasPlayed = false;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        BlackOpeningFade();
        Invoke("ButtonUIFade", 3.5f);
        Invoke("DialogueOpeningFade", 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlackOpeningFade()
    {
        if (gameObject.name == "ChapterStartOpening")
        {
            animator.SetTrigger("OpenIntro");
            Invoke("AddCheckTimer", 3f);
        }
    }

    public void ButtonUIFade()
    {
        if (gameObject.name == "ButtonUIFade")
        {
            animator.SetTrigger("ShowUIButtonFade_Black");
            Invoke("AddCheckTimer", 3.5f);
        }
    }

    public void DialogueOpeningFade()
    {
        if (gameObject.name == "DialogueStartOpening")
        {
            animator.SetTrigger("OpenIntro");
            Invoke("AddCheckTimer", 4f);
        }
    }

    void AddCheckTimer()
    {
        hasPlayed = true;
        this.gameObject.SetActive(false);
    }
}

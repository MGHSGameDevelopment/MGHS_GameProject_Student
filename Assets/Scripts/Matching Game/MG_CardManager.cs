using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MG_CardManager : MonoBehaviour
{
    [SerializeField] TMP_Text PointsText;
    [SerializeField] TMP_Text TimeLeft;

    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;

    [SerializeField] Button PauseButtonUI;

    [SerializeField] private int Points; //Matches Up to 5
    [SerializeField] private float _time; //60 Seconds

    [SerializeField] MG_Card CardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] private Sprite[] sprites;
    private List<Sprite> CardPair = new List<Sprite>();
    BibleEntity Card1;
    BibleEntity Card2;

    MG_Card firstCard;
    MG_Card SecondCard;
    GameObject cardtest;
    bool hasPicked;
    bool hasStart;
    void Start()
    {
        AudioManager.instance.PlayMusic("Noah_BG");
        hasStart = false;
        InitiateSprites();  
        CreateCards();
        TimeLeft.text = _time.ToString();
        PointsText.text = Points.ToString();
    }

    void Update()
    {
        if (hasStart)
        {
            if (_time <= 0)
            {
                AudioManager.instance.musicSource.Stop();
                LoseScreen.SetActive(true);
                _time = 0;
                PauseButtonUI.enabled = false;
            }
        }


    }

    public void SetSelected(MG_Card Card)
    {
        if (Card.isRevealed == false)
        {
            Card.ShowCard();
            if (firstCard == null)
            {
                firstCard = Card;
                return;
            }
            if (SecondCard == null)
            {
                SecondCard = Card;
                StartCoroutine(CheckMatchCards(firstCard,SecondCard));
                firstCard = null;
                SecondCard = null;
            }
        }
    }

    IEnumerator CheckMatchCards(MG_Card card1, MG_Card card2)
    {
        yield return new WaitForSeconds(.5f);
        if (card1.ImageSprite == card2.ImageSprite)
        {
            Debug.Log("Matched");
            AudioManager.instance.PlaySfx("Matching_Success");
            Points++;
            PointsText.text = Points.ToString();
            if (Points == 5)
            {
                AudioManager.instance.PlaySfx("GameWon");
                WinScreen.SetActive(true);
                PauseButtonUI.enabled = false;
                Time.timeScale = 0;
                Debug.Log("Success!");
            }
        }
        else
        {
            AudioManager.instance.PlaySfx("Matching_Fail");
            card1.HideCard();
            card2.HideCard();
        }
    }
    private void InitiateSprites()
    {
        CardPair = new List<Sprite>();
        for (int i = 0; i < sprites.Length; i++)
        {
            CardPair.Add(sprites[i]);
            CardPair.Add(sprites[i]);
        }
                    ShuffleCards(CardPair);
    }

    void ShuffleCards(List<Sprite> SpriteList)
    {
        for (int i = SpriteList.Count -1; i > 0; i--)
        {
            int RandomIndex = Random.Range(0, i + 1);

            Sprite temp = SpriteList[i];
            SpriteList[i] = SpriteList[RandomIndex];
            SpriteList[RandomIndex] = temp;
        }
    }

    void CreateCards()
    {
        for (int i = 0; i < CardPair.Count; i++)
        {
            MG_Card card = Instantiate(CardPrefab, gridTransform);
            card.SetImageSprite(CardPair[i]);
            card.cardManager = this;
        }
    }

    public void TriggerGameStart()
    {
        hasStart = true;
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (_time> 0)
        {
            _time--;
            TimeLeft.text = _time.ToString();
            yield return new WaitForSeconds(1f);
        }
    }

    public void RetryGameLevel()
    {
        Time.timeScale = 1;
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Debug.Log("GameResume");
    }

    public void GotoEpilogueScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Eplg_MatchingGame");
    }
}

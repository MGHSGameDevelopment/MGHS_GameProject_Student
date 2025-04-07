using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MG_Card : MonoBehaviour
{
    public BibleEntity Card;
    [SerializeField] private Image IconImage;
    public Sprite ImageSprite;
    public Sprite FlippedImageSprite;

    public bool isRevealed;
    public MG_CardManager cardManager;

    public void SetImageSprite(Sprite sp)
    {
        ImageSprite = sp;
    }

    public void ShowCard()
    {
        IconImage.sprite = ImageSprite;
        isRevealed = true;
    }

    public void HideCard()
    {
        IconImage.sprite = FlippedImageSprite;
        isRevealed = false;
    }
    public void CallCardDetectionTest()
    {
        Debug.Log("Detected");
    }

    public void OnCardClick()
    {
        AudioManager.instance.PlaySfx("Matching_Press");
        cardManager.SetSelected(this);
    }
}

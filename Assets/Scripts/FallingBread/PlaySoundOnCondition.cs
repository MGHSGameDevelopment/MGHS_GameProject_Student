using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySoundOnCondition : MonoBehaviour
{
    PlayButtonSound playSound;

    private void Start()
    {
        playSound = GetComponent<PlayButtonSound>();
        playSound.PlaySoundonButton();
    }
}

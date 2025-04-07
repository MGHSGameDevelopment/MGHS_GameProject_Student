using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    [SerializeField] private string _sfxName;

    public void PlaySoundonButton()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySfx(_sfxName);
        }
        else
        {
            Debug.LogWarning("AudioManager not found!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGMonMainMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.StopLoopingSfx();

        AudioManager.instance.PlayMusic("MainMenu_BG");
    }


}

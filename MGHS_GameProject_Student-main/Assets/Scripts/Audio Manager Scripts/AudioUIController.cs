using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    private void Start()
    {
        musicSlider.value = 1;
        sfxSlider.value = 1;
    }

    public void MuteMusic()
    {
        AudioManager.instance.MuteAudio();
    }
    public void MusicVolume()
    {
        AudioManager.instance.MusicVol(musicSlider.value);
    }
    public void SfxVolume()
    {
        AudioManager.instance.SfxVol(sfxSlider.value);
    }


}

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;   

        public Sound[] musicSounds, sfxSounds, loopingSfxSoundA, loopingSfxSoundB; 
        public AudioSource musicSource, sfxSource, loopingSfxSourceA, loopingSfxSourceB;

        private float _savedLoopingSfxTimeA = 0f;
        private float _savedLoopingSfxTimeB = 0f;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);

            if (s == null )
            {
                Debug.Log("Music not Found!");
                return;
            }
            else
            {
                musicSource.clip = s.clip;
                musicSource.loop = true;
                musicSource.Play();
            }
        }

        public void PlaySfx(string name)
        {
            Sound s = Array.Find(sfxSounds, x => x.name == name);

            if (s == null)
            {
                Debug.LogError("SFX not Found!");
                return;
            }
            else
            {
                sfxSource.PlayOneShot(s.clip, 2.0f);
            }
        }

        public void PlayLoopingSfxA(string name)
        {
            Sound s = Array.Find(loopingSfxSoundA, x => x.name == name);

            if (s == null)
            {
            Debug.LogError("Looping SFX A not Found! Name: " + name);
            return;
            }

            if (!loopingSfxSourceA.isPlaying) 
            {
                loopingSfxSourceA.clip = s.clip;
                loopingSfxSourceA.loop = true; 
                loopingSfxSourceA.Play();
            }
        }
        public void PlayLoopingSfxB(string name)
        {
        Sound s = Array.Find(loopingSfxSoundB, x => x.name == name);

        if (s == null)
        {
            Debug.LogError("Looping SFX B not Found!");
            return;
        }

        if (!loopingSfxSourceB.isPlaying)
        {
            loopingSfxSourceB.clip = s.clip;
            loopingSfxSourceB.loop = true;
            loopingSfxSourceB.Play();
        }

        Debug.Log("Playing Looping SFX B: " + name);
    }

        public void StopLoopingSfx()
        {
            if (loopingSfxSourceA.isPlaying)
            {
                loopingSfxSourceA.Stop();
            }
            if (loopingSfxSourceB.isPlaying)
            {
                loopingSfxSourceB.Stop();
            }
        }

        public void MuteAudio()
        {
            musicSource.mute = !musicSource.mute;
            sfxSource.mute = !sfxSource.mute;
            loopingSfxSourceA.mute = !loopingSfxSourceA.mute;
            loopingSfxSourceB.mute = !loopingSfxSourceB.mute;
        }

        public void MusicVol(float vol)
        {
            musicSource.volume = vol;
        }
        public void SfxVol(float vol)
        {
            sfxSource.volume = vol;
            loopingSfxSourceA.volume = vol;
            loopingSfxSourceB.volume = vol;
        }

        public void PauseLoopingSfx()
        {
            if (loopingSfxSourceA.isPlaying)
            {
                _savedLoopingSfxTimeA = loopingSfxSourceA.time;
                loopingSfxSourceA.Pause();
            }  
            if (loopingSfxSourceB.isPlaying)
            {
                _savedLoopingSfxTimeB = loopingSfxSourceB.time;
                loopingSfxSourceB.Pause();
            }
        }

        public void ResumeLoopingSfx()
        {
            if (!loopingSfxSourceA.isPlaying && loopingSfxSourceA.clip != null)
            {
                loopingSfxSourceA.time = _savedLoopingSfxTimeA;
                loopingSfxSourceA.Play();
            } 
            if (!loopingSfxSourceB.isPlaying && loopingSfxSourceB.clip != null)
            {
                loopingSfxSourceB.time = _savedLoopingSfxTimeB;
                loopingSfxSourceB.Play();
            }
        }
    }

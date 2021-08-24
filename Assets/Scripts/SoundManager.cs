using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sound[] sounds;
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {

        //Singlton creation

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //Singlton creation


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.PlayOnAwake;
            s.source.volume = volumeSlider.value;
            s.source.pitch = s.pitch;
            s.source.time = s.time;
        }

        Play("Background");
    }

    private void Update()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volumeSlider.value;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.Log("Typo");
            return;
        }
        s.source.Play();
    }

}

using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public Sound[] sounds;
    private void Awake() {
        Instance = this;
        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null) {
            Debug.LogWarning("Sound not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null) {
            Debug.LogWarning("Sound not found");
            return;
        }
        s.source.Stop();
    }

    public void StopAllSounds() {
        foreach(Sound s in sounds) {
            s.source.Stop();
        }
    }

    public void ChangeVolume(float vol) {
        foreach(Sound s in sounds) {
            s.source.volume = vol;
        }
    }
}

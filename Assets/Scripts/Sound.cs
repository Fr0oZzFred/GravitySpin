using UnityEngine;

[System.Serializable]
public class Sound {
    public string soundName;

    public AudioClip clip;
    [Range(0f,1f)]
    public float volume;
    public bool loop;
    public bool playOnAwake;
    [HideInInspector]
    public AudioSource source;
}

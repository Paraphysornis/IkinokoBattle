using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();
    [SerializeField] private AudioSource _audioSource;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("2D_SE");

        foreach (AudioClip clip in audioClips)
        {
            _clips.Add(clip.name, clip);
        }
    }

    public void Play(string clipName)
    {
        if (!_clips.ContainsKey(clipName))
        {
            throw new Exception("Sound " + clipName + " is not defined");
        }

        _audioSource.clip = _clips[clipName];
        _audioSource.Play();
    }
}

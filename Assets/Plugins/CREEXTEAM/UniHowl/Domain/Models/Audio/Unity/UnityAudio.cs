using System.Collections;
using System.Collections.Generic;
using Plugins.CREEXTEAM.UniHowl.Domain.ValueObject;
using UnityEngine;

public class UnityAudio : Entity<AudioKey>
{
    public UnityAudio(AudioKey key, AudioClip clip, AudioName name, AudioFolderPath path, bool preload)
    {
        Id = key;
        Clip = clip;
        Name = name;
        Path = path;
        Preload = preload;
    }
    
    public AudioClip Clip { get; private set; }
    public AudioName Name { get; private set; }
    public AudioFolderPath Path { get; private set; }
    public bool Preload { get; private set; }
}
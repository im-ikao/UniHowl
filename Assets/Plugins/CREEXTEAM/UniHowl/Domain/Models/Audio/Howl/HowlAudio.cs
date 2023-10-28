using System;
using Plugins.CREEXTEAM.UniHowl.Domain.ValueObject;

public sealed class HowlAudio : Entity<AudioKey>
{
    public HowlAudio(AudioKey key, AudioName name, AudioFolderPath path, bool preload)
    {
        Id = key;
        Name = name;
        Path = path;
        Preload = preload;
    }
    
    public AudioName Name { get; private set; }
    public AudioFolderPath Path { get; private set; }
    public bool Preload { get; private set; }
}

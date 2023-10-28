using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Plugins.CREEXTEAM.UniHowl.Domain.ValueObject;
using UnityEngine;

public class UnityAudioMap : Entity, IAudioMap<UnityAudio>
{
    private readonly Dictionary<string, UnityAudio> _audio = new();

    public UnityAudio Get(string key)
    {
        if (IsExist(key) == false)
            throw new ArgumentException(nameof(IsExist));

        return _audio[key];
    }
    
    public void Add(UnityAudio audio)
    {
        if (IsExist(audio) == true)
            throw new ArgumentException(nameof(IsExist));

        _audio.Add(audio.Id.Value, audio);
    }

    public void Remove(UnityAudio audio)
    {
        if (IsExist(audio) == false)
            throw new ArgumentException(nameof(IsExist));

        _audio.Remove(audio.Id.Value);
    }

    public void Clear()
    {
        _audio.Clear();
    }
    
    public bool IsExist(UnityAudio audio)
    {
        return IsExist(audio.Id.Value);
    }

    public bool IsExist(string key)
    {
        return _audio.ContainsKey(key);
    }

    public List<UnityAudio> GetAll()
    {
        return _audio.Values.ToList();
    }
}
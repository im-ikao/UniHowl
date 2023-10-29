using System;using Plugins.CREEXTEAM.UniHowl.Domain.ValueObject;
using Unity.VisualScripting;
using UnityEngine;

public class UnityAudioPlayer : IAudioPlayer
{
    private readonly AudioSource _source;
    private readonly IAudioMap<UnityAudio> _map;
    
    public UnityAudioPlayer(IAudioMap<UnityAudio> map, AudioSource source, string key, float volume, bool mute, bool loop)
    {
        _map = map;
        _source = source;
        
        SetSound(key);
        SetMute(mute);
        SetVolume(volume);
    }

    public void SetGlobalMute(bool state)
    {
        AudioListener.pause = state;
    }

    public void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetVolume(float volume)
    {
        _source.volume = volume;
    }

    public void SetMute(bool state)
    {
        _source.mute = state;
    }

    public void Play()
    {
        _source.Play();
    }

    public void Stop()
    {
        _source.Stop();
    }

    public float GetPlayTime()
    {
        return _source.time;
    }

    public void SetPlayTime(float time)
    {
        _source.time = time;
    }

    public bool IsPlaying()
    {
        return _source.isPlaying;
    }
    
    public float GetVolume()
    {
        return _source.volume;
    }

    public bool GetMute()
    {
        return _source.mute;
    }

    public void SetLoop(bool value)
    {
        _source.loop = value;
    }

    public bool GetLoop()
    {
        return _source.loop;
    }

    public void SetSound(string soundKey)
    {
        if (_map.IsExist(soundKey) == false)
            throw new ArgumentException(soundKey);

        var audio = _map.Get(soundKey);

        _source.clip = audio.Clip;
    }

    public void Load() { }
}

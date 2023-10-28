using System;
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
        SetMute(key, mute);
        SetVolume(key, volume);
    }

    public void SetGlobalMute(bool state)
    {
        throw new NotImplementedException();
    }

    public void SetGlobalVolume(float volume)
    {
        throw new NotImplementedException();
    }

    public void SetVolume(string key, float volume)
    {
        _source.volume = volume;
    }

    public void SetMute(string key, bool state)
    {
        _source.mute = state;
    }

    public void Play(string key)
    {
        _source.Play();
    }

    public void Stop(string key)
    {
        _source.Stop();
    }

    public float GetPlayTime(string key)
    {
        return _source.time;
    }

    public void SetPlayTime(string key, float time)
    {
        _source.time = time;
    }

    public bool IsPlaying(string key)
    {
        return _source.isPlaying;
    }
    
    public float GetVolume(string soundKey)
    {
        return _source.volume;
    }

    public bool GetMute(string soundKey)
    {
        return _source.mute;
    }

    public void SetLoop(string soundKey, bool value)
    {
        _source.loop = value;
    }

    public bool GetLoop(string soundKey)
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioPlayer
{
    public void SetGlobalMute(bool state);
    public void SetGlobalVolume(float volume);
    public void SetVolume(string key, float volume);
    public void SetMute(string key, bool state);
    public void Play(string key);
    public void Stop(string key);
    public float GetPlayTime(string key);
    public void SetPlayTime(string key, float time);
    public bool IsPlaying(string key);
    public float GetVolume(string soundKey);
    public bool GetMute(string soundKey);
    public void SetLoop(string soundKey, bool value);
    public bool GetLoop(string soundKey);
    public void SetSound(string soundKey);
}

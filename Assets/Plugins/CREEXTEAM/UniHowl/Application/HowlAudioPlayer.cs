using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowlAudioPlayer : IAudioPlayer
{
    public HowlAudioPlayer(IAudioMap<HowlAudio> map)
    {
        
    }

    public void SetGlobalMute(bool state) => HowlAudioProxy.SetGlobalMute(state);
    public void SetGlobalVolume(float volume) => HowlAudioProxy.SetGlobalVolume(volume);
    public void SetVolume(string key, float volume) => HowlAudioProxy.SetVolume(key, volume);
    public void SetMute(string key, bool state) => HowlAudioProxy.SetMute(key, state);
    public void Play(string key) => HowlAudioProxy.Play(key);
    public void Stop(string key) => HowlAudioProxy.Stop(key);
    public float GetPlayTime(string key) => HowlAudioProxy.GetPlayTime(key);
    public void SetPlayTime(string key, float time) => HowlAudioProxy.SetPlayTime(key, time);
    public bool IsPlaying(string key) => HowlAudioProxy.IsPlaying(key);
    public float GetVolume(string soundKey) => HowlAudioProxy.GetVolume(soundKey);
    public bool GetMute(string soundKey) => HowlAudioProxy.GetMute(soundKey);
    public void SetLoop(string soundKey, bool state) => HowlAudioProxy.SetLoop(soundKey, state);
    public bool GetLoop(string soundKey) => HowlAudioProxy.GetLoop(soundKey);
    public void SetSound(string soundKey) => HowlAudioProxy.GetVolume(soundKey);
}

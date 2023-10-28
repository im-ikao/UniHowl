using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class HowlAudioProxy
{
    public static void SetGlobalMute(bool state) => HowlGlobalMute(state);
    public static void SetGlobalVolume(float volume)  => HowlGlobalSetVolume(volume);
    public static void SetVolume(string key, float volume) => HowlSetVolume(key, volume);
    public static void SetMute(string key, bool state) => HowlMute(key, state);
    public static void Play(string key) => HowlPlay(key);
    public static void Stop(string key)  => HowlStop(key);
    public static float GetPlayTime(string key) => HowlGetPlayTime(key);
    public static void SetPlayTime(string key, float time) => HowlSetPlayTime(key, time);
    public static bool IsPlaying(string key) => HowlIsPlaying(key);
    public static float GetVolume(string soundKey) => HowlGetVolume(soundKey);
    public static bool GetLoop(string soundKey) => HowlGetLoop(soundKey);
    public static void SetLoop(string soundKey, bool state)  => HowlSetLoop(soundKey, state);
    public static bool GetMute(string soundKey) => HowlGetMute(soundKey);
    

    #region JavaScript External
    
    [DllImport("__Internal")]
    public static extern void HowlGlobalMute(bool state);
        
    [DllImport("__Internal")]
    public static extern void HowlGlobalSetVolume(float volume);
        
    [DllImport("__Internal")]
    public static extern void HowlSetVolume(string key, float value);
        
    [DllImport("__Internal")]
    public static extern void HowlMute(string key, bool value);
        
    [DllImport("__Internal")]
    public static extern void HowlStop(string key);
        
    [DllImport("__Internal")]
    public static extern void HowlPlay(string key);
        
    [DllImport("__Internal")]
    public static extern float HowlGetPlayTime(string key);
    
    [DllImport("__Internal")]
    public static extern void HowlSetPlayTime(string key, float value);
    
    [DllImport("__Internal")]
    public static extern bool HowlIsPlaying(string key);
    
    [DllImport("__Internal")]
    public static extern float HowlGetVolume(string soundKey);
    
    [DllImport("__Internal")]
    public static extern bool HowlGetLoop(string soundKey);
    
    [DllImport("__Internal")]
    public static extern void HowlSetLoop(string soundKey, bool state);
    
    [DllImport("__Internal")]
    public static extern bool HowlGetMute(string soundKey);
    
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class HowlAudioProxy
{
    public static void SetGlobalMute(bool state) => HowlGlobalMute(state);
    public static void SetGlobalVolume(float volume)  => HowlGlobalSetVolume(volume);
    public static void SetVolume(string sourceId, float volume) => HowlSetVolume(sourceId, volume);
    public static void SetMute(string sourceId, bool state) => HowlMute(sourceId, state);
    public static void Play(string sourceId) => HowlPlay(sourceId);
    public static void Stop(string sourceId)  => HowlStop(sourceId);
    public static float GetPlayTime(string sourceId) => HowlGetPlayTime(sourceId);
    public static void SetPlayTime(string sourceId, float time) => HowlSetPlayTime(sourceId, time);
    public static bool IsPlaying(string sourceId) => HowlIsPlaying(sourceId);
    public static float GetVolume(string sourceId) => HowlGetVolume(sourceId);
    public static bool GetLoop(string sourceId) => HowlGetLoop(sourceId);
    public static void SetLoop(string sourceId, bool state)  => HowlSetLoop(sourceId, state);
    public static bool GetMute(string sourceId) => HowlGetMute(sourceId);
    public static void SetSound(string sourceId, string key)
    {
        
    }


    #region JavaScript External
    
    [DllImport("__Internal")]
    public static extern void HowlGlobalMute(bool state);
        
    [DllImport("__Internal")]
    public static extern void HowlGlobalSetVolume(float volume);
        
    [DllImport("__Internal")]
    public static extern void HowlSetVolume(string sourceId, float value);
        
    [DllImport("__Internal")]
    public static extern void HowlMute(string sourceId, bool value);
        
    [DllImport("__Internal")]
    public static extern void HowlStop(string sourceId);
        
    [DllImport("__Internal")]
    public static extern void HowlPlay(string sourceId);
        
    [DllImport("__Internal")]
    public static extern float HowlGetPlayTime(string sourceId);
    
    [DllImport("__Internal")]
    public static extern void HowlSetPlayTime(string sourceId, float value);
    
    [DllImport("__Internal")]
    public static extern bool HowlIsPlaying(string sourceId);
    
    [DllImport("__Internal")]
    public static extern float HowlGetVolume(string soundSourceId);
    
    [DllImport("__Internal")]
    public static extern bool HowlGetLoop(string soundSourceId);
    
    [DllImport("__Internal")]
    public static extern void HowlSetLoop(string soundSourceId, bool state);
    
    [DllImport("__Internal")]
    public static extern bool HowlGetMute(string soundSourceId);
    
    #endregion

}

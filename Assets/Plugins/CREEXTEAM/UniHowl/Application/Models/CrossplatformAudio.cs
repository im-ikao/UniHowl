using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public class CrossplatformAudio
{
    public string Key;
    
#if !UNITY_WEBGL || UNITY_EDITOR
    public AudioClip Clip;
#endif
    
    public bool Preload = true;
    
    [HideInInspector] public string FolderPath;
    [HideInInspector] public string Name;
    
#if !UNITY_WEBGL || UNITY_EDITOR
    public void RefreshAudioInfo()
    {
        if (Clip == null)
            throw new NullReferenceException(nameof(Clip));
        
        var assetPath = AssetDatabase.GetAssetPath(Clip);
        
        Name = Path.GetFileName(assetPath);
        FolderPath = Path.GetRelativePath("Assets", assetPath);
        FolderPath = FolderPath.Remove(FolderPath.Length - Name.Length, Name.Length);

    }
#endif
    
//#if UNITY_WEBGL
    public HowlAudio ToHowlAudio()
    {
        return new HowlAudio(
            new AudioKey(Key),
            new AudioName(Name),
            new AudioFolderPath(FolderPath),
            Preload);
    } 
//#endif

#if !UNITY_WEBGL || UNITY_EDITOR
    public UnityAudio ToUnityAudio()
    {
        return new UnityAudio(
            new AudioKey(Key),
            Clip,
            new AudioName(Name),
            new AudioFolderPath(FolderPath),
            Preload);
    }
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfiguration")]
public class AudioConfiguration : ScriptableObject
{
    private const string _path = "Assets/Resources";
    private const string _name = "AudioConfiguration";

    [SerializeField] 
    private bool _debug = true;
    public bool Debug => _debug;
    
    [SerializeField] 
    private CrossplatformAudioMap _audio;
    public CrossplatformAudioMap Audio => _audio;
    
    private static AudioConfiguration _instance;

#if UNITY_EDITOR
    [InitializeOnLoadMethod]
#endif
    public static AudioConfiguration GetInstance()
    {
        if (_instance != null)
            return _instance;

        _instance = Resources.Load<AudioConfiguration>(_name);
            
#if UNITY_EDITOR
        var assetPath = $"{_path}/{_name}.asset";

        if (_instance != null) 
            return _instance;
        
        if (AssetDatabase.IsValidFolder("Assets/Resources") == false)
            AssetDatabase.CreateFolder("Assets", "Resources");
                
        _instance = CreateInstance<AudioConfiguration>();
        AssetDatabase.CreateAsset(_instance, assetPath);
        AssetDatabase.SaveAssetIfDirty(_instance);
#endif
            
        return _instance;
    }
}

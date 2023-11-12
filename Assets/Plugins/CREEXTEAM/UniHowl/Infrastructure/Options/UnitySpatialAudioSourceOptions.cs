using UniHowl.Domain;
using UnityEngine;
using UnityEngine.Audio;

namespace UniHowl.Spatial.Options
{
#if !UNITY_WEBGL || UNITY_EDITOR
    public class UnitySpatialAudioSourceOptions : ISpatialAudioSourceOptions
    {
        /// <summary>
        /// ENUM TO CLASS CONVERT FIELD;
        /// </summary>
        public AudioPlayers FallbackPlayer => AudioPlayers.Unity;
        
        public float Pitch = 1;
        public AudioMixerGroup Output;
        
        public bool BypassEffects = false;
        public bool BypassListenerEffects = false;
        public bool BypassReverbZones = false;
        
        public float StereoPan = 0;
        public float SpatialBlend = 0;
        public float ReverbZoneMix = 1;

        public float DopplerLevel = 1;
        public float Spread = 0;
        public AudioRolloffMode VolumeRolloff = AudioRolloffMode.Logarithmic;
        public float MinDistance = 1;
        public float MaxDistance = 500;
    }
#endif
}
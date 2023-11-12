using System;
using Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers;
using UniHowl.Domain;
using UnityEngine;
using UnityEngine.Audio;

namespace UniHowl.Spatial.Options
{
#if !UNITY_WEBGL || UNITY_EDITOR
    public class UnitySpatialAudioSourceBehaviourOption : MonoBehaviour, IBehaviourSpatialAudioSourceOptions
    {
        private UnitySpatialAudioSourceOptions _options;
        
        [SerializeField] private AudioMixerGroup _output;
        
        [SerializeField] private bool _bypassEffects = false;
        [SerializeField] private bool _bypassListenerEffects = false;
        [SerializeField] private bool _bypassReverbZones = false;
        
        [SerializeField] private float _stereoPan = 0;
        [SerializeField] private float _spatialBlend = 0;
        [SerializeField] private float _reverbZoneMix = 1;

        [SerializeField] private float _dopplerLevel = 1;
        [SerializeField] private float _spread = 0;
        [SerializeField] private AudioRolloffMode _volumeRolloff = AudioRolloffMode.Logarithmic;
        [SerializeField] private float _minDistance = 1;
        [SerializeField] private float _maxDistance = 500;

        public bool IsInitialized => _options != null; // TODO: TEMPORARY
        
        public void Initialize()
        {
             if (_options != null)
                 return;
             
             _options = new UnitySpatialAudioSourceOptions()
            {
                Output = _output,
                BypassEffects = _bypassEffects,
                BypassListenerEffects = _bypassListenerEffects,
                BypassReverbZones = _bypassReverbZones,
                StereoPan = _stereoPan,
                SpatialBlend = _spatialBlend,
                ReverbZoneMix = _reverbZoneMix,
                DopplerLevel = _dopplerLevel,
                Spread = _spread,
                VolumeRolloff = _volumeRolloff,
                MinDistance = _minDistance,
                MaxDistance = _maxDistance
            };
        }
#if UNITY_EDITOR
        public void OnValidate()
        {
            if (_options == null)
                return;
            
            _options.Output = _output;
            _options.BypassEffects = _bypassEffects;
            _options.BypassListenerEffects = _bypassListenerEffects;
            _options.BypassReverbZones = _bypassReverbZones;
            _options.StereoPan = _stereoPan;
            _options.SpatialBlend = _spatialBlend;
            _options.ReverbZoneMix = _reverbZoneMix;
            _options.DopplerLevel = _dopplerLevel;
            _options.Spread = _spread;
            _options.VolumeRolloff = _volumeRolloff;
            _options.MinDistance = _minDistance;
            _options.MaxDistance = _maxDistance;
        }
#endif
        
        public ISpatialAudioSourceOptions GetOptions()
        {
            return _options;
        }
    }

#endif
}

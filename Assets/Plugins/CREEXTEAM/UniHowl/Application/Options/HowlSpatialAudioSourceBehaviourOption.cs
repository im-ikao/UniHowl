using System;
using Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers;
using UniHowl.Domain;
using UnityEngine;
using UnityEngine.Serialization;

namespace UniHowl.Spatial.Options
{
    
#if UNITY_WEBGL || UNITY_EDITOR
    public class HowlSpatialAudioSourceBehaviourOption : MonoBehaviour, IBehaviourSpatialAudioSourceOptions
    {
        [SerializeField] private HowlSpatialAudioSourceOptions _options;
        
        [SerializeField] private HowlPanningMode _panningModel;
        [SerializeField] private HowlDistanceMode _distanceModel;
        [SerializeField] [Range(0, 360)] private float _innerAngle;
        [SerializeField] [Range(0, 360)] private float _outerAngle;
        [SerializeField] [Range(0, 1)] private float _outerGain;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _refDistance;
        [SerializeField] private float _rolloffFactor;

        private bool _isInitialized = false;
        public bool IsInitialized => _isInitialized; // TODO: TEMPORARY

        public void Initialize()
        {
            if (_isInitialized == true)
                return;
            
            _isInitialized = true;
            
            _options = new HowlSpatialAudioSourceOptions(panningMode: _panningModel,
                distanceMode: _distanceModel,
                innerAngle: _innerAngle, 
                outerAngle: _outerAngle, 
                outerGain: _outerGain,
                maxDistance: _maxDistance,
                refDistance: _refDistance,
                rollOffFactor: _rolloffFactor);
        }
        private void OnValidate()
        {
            _options.PanningMode = _panningModel;
            _options.DistanceMode = _distanceModel;
            _options.InnerAngle = _innerAngle;
            _options.OuterAngle = _outerAngle;
            _options.OuterGain = _outerGain;
            _options.MaxDistance = _maxDistance;
            _options.RefDistance = _refDistance;
            _options.RollOffFactor = _rolloffFactor;
        }

        public ISpatialAudioSourceOptions GetOptions()
        {
            return _options;
        }
    }
    
#endif
}
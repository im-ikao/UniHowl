using System;
using Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers;
using UniHowl.Domain;
using UnityEngine;
using UnityEngine.Serialization;

namespace UniHowl.Spatial.Options
{
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

        public bool IsInitialized => _options != null; // TODO: TEMPORARY

        public void Initialize()
        {
            _options = new HowlSpatialAudioSourceOptions
            {
                PanningMode = _panningModel,
                DistanceMode = _distanceModel,
                InnerAngle = _innerAngle,
                OuterAngle = _outerAngle,
                OuterGain = _outerGain,
                MaxDistance = _maxDistance,
                RefDistance = _refDistance,
                RollOffFactor = _rolloffFactor
            };
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
}
using System;
using Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers;
using UniHowl.Domain;
using UnityEngine;
using UnityEngine.Serialization;

namespace UniHowl.Spatial.Options
{
    public class HowlSpatialAudioSourceBehaviourOption : MonoBehaviour, IBehaviourSpatialAudioSourceOptions
    {
        [SerializeField]
        private HowlSpatialAudioSourceOptions options;

        [SerializeField] private HowlPanningMode _panningModel;
        [SerializeField] private HowlDistanceMode _distanceModel;
        [SerializeField] [Range(0, 360)] private float _innerAngle;
        [SerializeField] [Range(0, 360)] private float _outerAngle;
        [SerializeField] [Range(0, 1)] private float _outerGain;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _refDistance;
        [SerializeField] private float _rolloffFactor;

        private void Awake()
        {
            options = new HowlSpatialAudioSourceOptions
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
            options.PanningMode = _panningModel;
            options.DistanceMode = _distanceModel;
            options.InnerAngle = _innerAngle;
            options.OuterAngle = _outerAngle;
            options.OuterGain = _outerGain;
            options.MaxDistance = _maxDistance;
            options.RefDistance = _refDistance;
            options.RollOffFactor = _rolloffFactor;
        }

        public ISpatialAudioSourceOptions GetOptions()
        {
            return options;
        }
    }
}
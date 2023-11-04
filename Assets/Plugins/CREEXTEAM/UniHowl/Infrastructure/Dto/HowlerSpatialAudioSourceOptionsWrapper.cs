using System;
using UniHowl.Spatial.Options;

namespace Plugins.CREEXTEAM.UniHowl.Infrastructure.Dto
{
    // Why this strange object?
    // I wouldn’t want to drag along a custom serializer, and in order not to constantly create garbage,
    // we created such a wrapper to json object
    public class HowlerSpatialAudioSourceOptionsWrapper
    {
        public string panningModel;
        public string distanceModel;
        public float coneInnerAngle;
        public float coneOuterAngle;
        public float coneOuterGain;
        public float refDistance;
        public float maxDistance;
        public float rolloffFactor;

        public HowlerSpatialAudioSourceOptionsWrapper(
            HowlPanningMode panningModel,
            HowlDistanceMode distanceModel, 
            float coneInnerAngle,
            float coneOuterAngle,
            float coneOuterGain, 
            float maxDistance, 
            float refDistance,
            float rolloffFactor)
        {
            SetPanningMode(panningModel);
            SetDistanceMode(distanceModel);

            this.coneInnerAngle = coneInnerAngle;
            this.coneOuterAngle = coneOuterAngle;
            this.coneOuterGain = coneOuterGain;
            this.maxDistance = maxDistance;
            this.refDistance = refDistance;
            this.rolloffFactor = rolloffFactor;
        }

        public HowlPanningMode GetPanningMode()
        {
            return panningModel switch
            {
                "HRTF" => HowlPanningMode.HRTF,
                "equalpower" => HowlPanningMode.EqualPower,
                _ => HowlPanningMode.HRTF
            };
        }
        
        public HowlDistanceMode GetDistanceMode()
        {
            return panningModel switch
            {
                "exponential" => HowlDistanceMode.Exponential,
                "inverse" => HowlDistanceMode.Inverse,
                "linear" => HowlDistanceMode.Linear,
                _ => HowlDistanceMode.Exponential
            };
        }
        
        public void SetPanningMode(HowlPanningMode mode)
        {
            this.panningModel = mode switch
            {
                HowlPanningMode.HRTF => "HRTF",
                HowlPanningMode.EqualPower => "equalpower",
                _ => throw new NotSupportedException()
            };
        }

        public void SetDistanceMode(HowlDistanceMode mode)
        {
            this.distanceModel = mode switch
            {
                HowlDistanceMode.Exponential => "exponential",
                HowlDistanceMode.Inverse => "inverse",
                HowlDistanceMode.Linear => "linear",
                _ => throw new NotSupportedException()
            };
        }
    }
}
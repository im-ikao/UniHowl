using System;
using Plugins.CREEXTEAM.UniHowl.Infrastructure.Dto;
using UniHowl.Domain;
using UnityEngine;

namespace UniHowl.Spatial.Options
{
    // Why is not inherited from some universal class?
    // Because in cross-platform games we can sacrifice some features for the sake of performance or platform support
    [Serializable]
    public class HowlSpatialAudioSourceOptions : ISpatialAudioSourceOptions
    {
        private HowlerSpatialAudioSourceOptionsWrapper _wrapper = new(
            HowlPanningMode.HRTF, 
            HowlDistanceMode.Exponential, 
            360, 
            360, 
            0, 
            10000,
            1, 
            1);
        
        /// <summary>
        /// ENUM TO CLASS CONVERT FIELD;
        /// </summary>
        public AudioPlayers FallbackPlayer => AudioPlayers.Howl;
        
        /// <summary>
        /// Determines which spatialization algorithm is used to position audio. Can be HRTF or equalpower.
        /// </summary>
        public HowlPanningMode PanningMode
        {
            get => _wrapper.GetPanningMode();
            set => _wrapper.SetPanningMode(value);
        }

        /// <summary>
        /// How quickly the volume reduces as source moves from listener.
        /// This is simply a variable of the distance model and can be in the range
        /// of [0, 1] with linear and
        /// [0, ∞] with inverse and exponential
        /// </summary>
        public float RollOffFactor
        {
            get => _wrapper.rolloffFactor;
            set => _wrapper.rolloffFactor = value;
        }

        /// <summary>
        /// The maximum distance between source and listener, after which the volume will not be reduced any further.
        /// </summary>
        public float MaxDistance
        {
            get => _wrapper.maxDistance;
            set => _wrapper.maxDistance = value;
        }

        /// <summary>
        /// A reference distance for reducing volume as source moves further from the listener.
        /// This is simply a variable of the distance model and has a different effect depending on which model is used and the scale of your coordinates.
        /// Generally, volume will be equal to 1 at this distance.
        /// </summary>
        public float RefDistance
        {
            get => _wrapper.refDistance;
            set => _wrapper.refDistance = value;
        }

        /// <summary>
        /// Determines algorithm used to reduce volume as audio moves away from listener.
        /// Can be linear, inverse or exponential. You can find the implementations of each in the spec.
        /// </summary>
        public HowlDistanceMode DistanceMode
        {
            get => _wrapper.GetDistanceMode();
            set => _wrapper.SetDistanceMode(value);
        }

        /// <summary>
        /// A parameter for directional audio sources, this is the gain outside of the coneOuterAngle.
        /// It is a linear value in the range [0, 1].
        /// </summary>
        public float OuterGain
        {
            get => _wrapper.coneOuterGain;
            set => _wrapper.coneOuterGain = value;
        }

        /// <summary>
        /// A parameter for directional audio sources, this is an angle, in degrees, outside of which the volume will be reduced to a constant value of coneOuterGain.
        /// </summary>
        public float OuterAngle
        {
            get => _wrapper.coneOuterAngle;
            set => _wrapper.coneOuterAngle = value;
        }

        /// <summary>
        ///  A parameter for directional audio sources, this is an angle, in degrees, inside of which there will be no volume reduction.
        /// </summary>
        public float InnerAngle
        {
            get => _wrapper.coneInnerAngle;
            set => _wrapper.coneInnerAngle = value;
        }
        
        public string ToJson() => JsonUtility.ToJson(_wrapper);
    }
    
    public enum HowlDistanceMode
    {
            Linear,
            Inverse,
            Exponential
    }

    public enum HowlPanningMode
    {
        HRTF,
        EqualPower
    }
}
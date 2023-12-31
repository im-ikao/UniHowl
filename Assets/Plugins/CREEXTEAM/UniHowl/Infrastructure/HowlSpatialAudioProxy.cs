﻿using System;
using System.Runtime.InteropServices;
using UniHowl.Spatial.Options;
using UnityEngine;

namespace Plugins.CREEXTEAM.UniHowl.Infrastructure
{
#if UNITY_WEBGL && !UNITY_EDITOR
    public static class HowlSpatialAudioProxy
    {
        public static void SetPan(string sourceId, HowlSpatialAudioSourceOptions options)
        {
            HowlSetPan(sourceId, options.ToJson());
        }
        
        public static void SetPosition(string sourceId, Vector3 position)
        {
            HowlSetPosition(sourceId, position.x, position.y, position.z);
        }
        
        public static void AudioListenerSetPosition(Vector3 position)
        {
            HowlAudioListenerSetPosition(position.x, position.y, position.z);
        }

        public static void AudioListenerSetRotation(Vector3 rotation, Vector3 coordinateSystem)
        {
            HowlAudioListenerSetRotation(rotation.x, rotation.y, rotation.z, coordinateSystem.x, coordinateSystem.y, coordinateSystem.z);
        }
        
        [DllImport("__Internal")]
        public static extern bool HowlSetPan(string sourceId, string options);
        
        [DllImport("__Internal")]
        public static extern bool HowlSetPosition(string sourceId, float x, float y, float z);
        
        [DllImport("__Internal")]
        public static extern bool HowlAudioListenerSetPosition(float x, float y, float z);
        
        [DllImport("__Internal")]
        public static extern bool HowlAudioListenerSetRotation(float x, float y, float z, float xUp, float yUp, float zUp);
        
    }
    #endif
}
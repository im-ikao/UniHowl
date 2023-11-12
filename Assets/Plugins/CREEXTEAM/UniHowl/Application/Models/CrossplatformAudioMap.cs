using System;
using System.Collections.Generic;
using System.Linq;
using UniHowl.Domain;
using UnityEngine;

namespace UniHowl
{
    [CreateAssetMenu]
    [Serializable]
    public class CrossplatformAudioMap : ScriptableObject
    {
        [SerializeField] private List<CrossplatformAudio> _audio = new();

#if UNITY_WEBGL
        public IAudioMap<HowlAudio> ToHowlAudioMap()
        {
            var map = new HowlAudioMap();

            foreach (var unityAudio in _audio.Select(audio => audio.ToHowlAudio()))
            {
                map.Add(unityAudio);
            }

            return map;
        }
#endif

#if !UNITY_WEBGL || UNITY_EDITOR
        public IAudioMap<UnityAudio> ToUnityAudioMap()
        {
            var map = new UnityAudioMap();

            foreach (var howlAudio in _audio.Select(audio => audio.ToUnityAudio()))
            {
                map.Add(howlAudio);
            }

            return map;
        }

        public void OnValidate()
        {
            foreach (var audio in _audio.Where(audio => audio.Clip != null))
            {
                audio.RefreshAudioInfo();
            }
        }
#endif
    }
}
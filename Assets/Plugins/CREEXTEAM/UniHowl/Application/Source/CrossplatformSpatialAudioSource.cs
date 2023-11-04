using System;
using UniHowl.Domain;
using UniHowl.Spatial.Options;
using UnityEngine;

namespace UniHowl.Spatial
{
    public class CrossplatformSpatialAudioSource : CrossplatformAudioSource
    {
        [SerializeField] 
        private bool _isSpatial;
        
        private ISpatialAudioSource _spatial;
        private ISpatialAudioSourceOptions _options;

        // TODO: HIDE UNSUPPORTED INIT

        private void Update()
        {
            if (_isSpatial && _spatial != null)
                _spatial.Update();
        }

        public void Init(AudioConfiguration configuration,
            ISpatialAudioSourceOptionsProvider optionsProvider)
        {
            base.Init(configuration);
                     
#if !UNITY_WEBGL || UNITY_EDITOR
            if (_isSpatial)
            {
                _spatial = new UnitySpatialPositionSource(Id, this.GetComponent<AudioSource>(), optionsProvider.GetOptions<UnitySpatialAudioSourceOptions>(AudioPlayers.Unity));
                return;
            }
#endif
            
            if (_isSpatial)
            {
                _spatial = _fallbackPlayer switch
                {
#if UNITY_WEBGL
                    AudioPlayers.Howl => new HowlSpatialPositionSource(Id, this.transform, optionsProvider.GetOptions<HowlSpatialAudioSourceOptions>(AudioPlayers.Howl)),
#endif
#if !UNITY_WEBGL || UNITY_EDITOR
                    AudioPlayers.Unity => new UnitySpatialPositionSource(Id, this.GetComponent<AudioSource>(), optionsProvider.GetOptions<UnitySpatialAudioSourceOptions>(AudioPlayers.Unity)), // TODO: TEMPORARY
#endif
                    _ => throw new ArgumentOutOfRangeException(nameof(_fallbackPlayer))
                };
            }
            
            Debug.Log("ok");
        }
    }
}
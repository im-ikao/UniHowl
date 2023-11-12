using System;
using UniHowl.Domain;
using UniHowl.Spatial.Options;
using UnityEngine;

namespace UniHowl.Spatial
{
    public class UnitySpatialPositionSource : Entity<Guid>, ISpatialAudioSource
    {
        private readonly AudioSource _source;
        private readonly UnitySpatialAudioSourceOptions _options;

        public UnitySpatialPositionSource(Guid id, AudioSource source, UnitySpatialAudioSourceOptions options)
        {
            _source = source;
            _options = options;
            
            Id = id;
        }

        public void Initialize()
        {
            RefreshOptions();
        }
        
        public void RefreshOptions()
        {
            _source.outputAudioMixerGroup = _options.Output;
            _source.bypassEffects = _options.BypassEffects;
            _source.bypassListenerEffects = _options.BypassListenerEffects;
            _source.bypassReverbZones = _options.BypassReverbZones;
            _source.panStereo = _options.StereoPan;
            _source.spatialBlend = _options.SpatialBlend;
            _source.dopplerLevel = _options.DopplerLevel;
            _source.spread = _options.Spread;
            _source.rolloffMode = _options.VolumeRolloff;
            _source.minDistance = _options.MinDistance;
            _source.maxDistance = _options.MaxDistance;
        }
        
        // NOT NEEDED, IT MADE AUTO;
        public void Update() { }
        public void SetPosition(Vector3 position) { }
    }
}
using System;
using Plugins.CREEXTEAM.UniHowl.Infrastructure;
using UniHowl.Domain;
using UniHowl.Spatial.Options;
using UnityEngine;

namespace UniHowl.Spatial
{
    public class HowlSpatialPositionSource : Entity<Guid>, ISpatialAudioSource
    {
        private readonly string _id;
        
        private readonly HowlSpatialAudioSourceOptions _options;
        
        private readonly Transform _origin;
        private Vector3 _latestPosition;

        public HowlSpatialPositionSource(Guid id, Transform origin, HowlSpatialAudioSourceOptions options)
        {
            Id = id;
            _id = Id.ToString();
            _origin = origin;
            _options = options;

            RefreshOptions();
            SetPosition(_origin.position);
        }

        public void RefreshOptions()
        {
            HowlSpatialAudioProxy.SetPan(_id, _options);
        }
        
        public void Update()
        {
            SetPosition(_origin.position);
        }
        
        public void SetPosition(Vector3 position)
        {
            if (_latestPosition == position)
                return;

            _latestPosition = position;
            
            HowlSpatialAudioProxy.SetPosition(_id, position);
        }
    }
}
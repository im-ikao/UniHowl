using Plugins.CREEXTEAM.UniHowl.Infrastructure;
using UniHowl.Domain;
using UnityEngine;

namespace UniHowl.Spatial
{
    public class HowlSpatialPositionSource : ISpatialAudioSource
    {
        private readonly Transform _origin;
        private Vector3 _latestPosition;

        public HowlSpatialPositionSource(Transform origin)
        {
            _origin = origin;
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
            
            HowlSpatialAudioProxy.HowlSetPosition(position);
        }
    }
}
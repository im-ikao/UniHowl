using Plugins.CREEXTEAM.UniHowl.Infrastructure;
using UnityEngine;

namespace UniHowl.Spatial
{
    public class HowlSpatialAudioListenerSource : MonoBehaviour
    {
#if UNITY_WEBGL
        private static readonly Vector3 _coordinateSystem = Vector3.up;
        private Vector3 _latestPosition;
        private Vector3 _latestRotation;

        public void Update()
        {
            SetPosition(transform.position);
            SetPosition(transform.rotation.eulerAngles);
        }

        private void SetPosition(Vector3 position)
        {
            if (_latestPosition == position)
                return;

            _latestPosition = position;
            
            HowlSpatialAudioProxy.HowlAudioListenerSetPosition(position);
        }

        private void SetRotation(Vector3 rotation)
        {
            if (_latestPosition == rotation)
                return;

            _latestPosition = rotation;
            
            HowlSpatialAudioProxy.HowlAudioListenerSetRotation(rotation, _coordinateSystem);
        }
#endif
    }
}
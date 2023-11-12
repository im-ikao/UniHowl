using Plugins.CREEXTEAM.UniHowl.Infrastructure;
using UnityEngine;

namespace UniHowl.Spatial
{
#if UNITY_WEBGL && !UNITY_EDITOR
    public class HowlSpatialAudioListenerSource : MonoBehaviour
    {
        private static readonly Vector3 _coordinateSystem = Vector3.up;
        private Vector3 _latestPosition;
        private Vector3 _latestRotation;

        public void Update()
        {
            SetPosition(transform.position);
            SetRotation(transform.rotation.eulerAngles);
        }

        private void SetPosition(Vector3 position)
        {
            if (_latestPosition == position)
                return;

            _latestPosition = position;
            
            HowlSpatialAudioProxy.AudioListenerSetPosition(position);
        }

        private void SetRotation(Vector3 rotation)
        {
            if (_latestPosition == rotation)
                return;

            _latestPosition = rotation;
            
            HowlSpatialAudioProxy.AudioListenerSetRotation(rotation, _coordinateSystem);
        }
    }
#endif
}
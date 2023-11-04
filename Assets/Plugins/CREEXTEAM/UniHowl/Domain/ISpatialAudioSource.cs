using UnityEngine;

namespace UniHowl.Domain
{
    public interface ISpatialAudioSource
    {
        public void Update();
        public void SetPosition(Vector3 position);
    }
}
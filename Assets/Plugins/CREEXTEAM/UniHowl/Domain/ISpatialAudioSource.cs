using UnityEngine;

namespace UniHowl.Domain
{
    public interface ISpatialAudioSource
    {
        public void RefreshOptions();
        public void Update();
        public void Initialize();
        public void SetPosition(Vector3 position);
    }
}
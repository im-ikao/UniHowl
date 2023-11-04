using UniHowl.Domain;

namespace Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers
{
    public interface IBehaviourSpatialAudioSourceOptions
    {
        public bool IsInitialized { get; }
        public ISpatialAudioSourceOptions GetOptions();
        void Initialize();
    }
}
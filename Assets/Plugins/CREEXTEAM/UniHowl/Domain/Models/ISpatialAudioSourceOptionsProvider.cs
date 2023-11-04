namespace UniHowl.Domain
{
    public interface ISpatialAudioSourceOptionsProvider
    {
        public void Scan();
        public TOptions GetOptions<TOptions>(AudioPlayers player) where TOptions : class, ISpatialAudioSourceOptions;
    }
}
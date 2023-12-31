using System;
using UniHowl.Domain;

namespace UniHowl
{
    #if UNITY_WEBGL && !UNITY_EDITOR
    public sealed class HowlAudioPlayer : Entity<Guid>, IAudioPlayer
    {
        private readonly string _id;
        
        public HowlAudioPlayer(Guid id, IAudioMap<HowlAudio> map, string key, float volume, bool mute, bool loop)
        {
            Id = id;
            _id = Id.ToString();

            if (map.IsExist(key) == false)
                throw new ArgumentException(nameof(HowlAudioPlayer));

            var audio = map.Get(key);

            HowlAudioProxy.CreateAudio(_id, $"{audio.Path.FolderPath}\\{audio.Name.Value}", loop, volume, mute, false);
        }
        
        public void SetGlobalMute(bool state) => HowlAudioProxy.SetGlobalMute(state);
        public void SetGlobalVolume(float volume) => HowlAudioProxy.SetGlobalVolume(volume);
        public void SetVolume(float volume) => HowlAudioProxy.SetVolume(_id, volume);
        public void SetMute(bool state) => HowlAudioProxy.SetMute(_id, state);
        public void Play() => HowlAudioProxy.Play(_id);
        public void Stop() => HowlAudioProxy.Stop(_id);
        public float GetPlayTime() => HowlAudioProxy.GetPlayTime(_id);
        public void SetPlayTime(float time) => HowlAudioProxy.SetPlayTime(_id, time);
        public bool IsPlaying() => HowlAudioProxy.IsPlaying(_id);
        public float GetVolume() => HowlAudioProxy.GetVolume(_id);
        public bool GetMute() => HowlAudioProxy.GetMute(_id);
        public void SetLoop(bool state) => HowlAudioProxy.SetLoop(_id, state);
        public bool GetLoop() => HowlAudioProxy.GetLoop(_id);
        public void SetSound(string key) => HowlAudioProxy.SetSound(_id, key);
        public void Load() => HowlAudioProxy.Load(_id);
        public Guid GetId() => Id;
    }
    #endif
}

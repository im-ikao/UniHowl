using System;

namespace UniHowl.Domain
{
    public interface IAudioPlayer
    {
        public void SetGlobalMute(bool state);
        public void SetGlobalVolume(float volume);
        public void SetVolume(float volume);
        public void SetMute(bool state);
        public void Play();
        public void Stop();
        public float GetPlayTime();
        public void SetPlayTime(float time);
        public bool IsPlaying();
        public float GetVolume();
        public bool GetMute();
        public void SetLoop(bool value);
        public bool GetLoop();
        public void SetSound(string key);
        public void Load();
        public Guid GetId();
    }
}
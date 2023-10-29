using System;
using System.Collections.Generic;
using System.Linq;

namespace UniHowl.Domain
{
    public class HowlAudioMap : Entity, IAudioMap<HowlAudio>
    {
        private readonly Dictionary<string, HowlAudio> _audio = new();

        public HowlAudio Get(string key)
        {
            if (IsExist(key) == false)
                throw new ArgumentException(nameof(IsExist));

            return _audio[key];
        }

        public void Add(HowlAudio audio)
        {
            if (IsExist(audio) == true)
                throw new ArgumentException(nameof(IsExist));

            _audio.Add(audio.Id.Value, audio);
        }

        public void Remove(HowlAudio audio)
        {
            if (IsExist(audio) == false)
                throw new ArgumentException(nameof(IsExist));

            _audio.Remove(audio.Id.Value);
        }

        public void Clear()
        {
            _audio.Clear();
        }

        public bool IsExist(HowlAudio audio)
        {
            return IsExist(audio.Id.Value);
        }

        public bool IsExist(string key)
        {
            return _audio.ContainsKey(key);
        }

        public List<HowlAudio> GetAll()
        {
            return _audio.Values.ToList();
        }
    }
}
using System;
using UniHowl.Domain;
using UniHowl.Spatial;
using UnityEngine;

namespace UniHowl
{
    public class CrossplatformAudioSource : MonoBehaviour, IEntity<Guid>
    {
        public Guid Id { get; set; }
        private string _id;
        
        [SerializeField] 
        protected AudioPlayers _fallbackPlayer = AudioPlayers.Howl;

        [SerializeField] 
        private string _soundKey;

        [SerializeField] 
        private float _volume;
        
        [SerializeField]
        private bool _loop;
        
        [SerializeField] 
        private bool _mute;

        [SerializeField]
        private bool _autoInit;
        
        private IAudioPlayer _player;

        #region InGameChange

        public float Volume
        {
            get => _volume;
            set
            {
                _volume = _player.GetVolume();
                _player.SetVolume(value);
            }
        }

        public bool Mute
        {
            get => _player.GetMute();
            set
            {
                _mute = value;
                _player.SetMute(value);
            }
        }

        public bool Loop
        {
            get => _player.GetLoop();
            set
            {
                _loop = value;
                _player.SetLoop(value);
            }
        }

        public string SoundKey
        {
            get => _soundKey;
            set
            {
                _soundKey = value;
                _player.SetSound(value);
            }
        }

        #endregion

#if !UNITY_WEBGL || UNITY_EDITOR
        public void OnValidate()
        {
            if (_player == null)
                return;

            Volume = _volume;
            Mute = _mute;
            Loop = _loop;
            SoundKey = _soundKey;
        }
#endif

        private void Awake()
        {
            if (_autoInit == true)
                AutoInitialize();
        }

        protected virtual void AutoInitialize()
        {
            Init(AudioConfiguration.GetInstance());
        }

        public void Init(AudioConfiguration configuration)
        {
            Id = Guid.NewGuid();
            _id = Id.ToString();

            if (Application.isEditor && configuration.Debug)
            {
#if UNITY_EDITOR
                _player = new UnityAudioPlayer(Id, configuration.Audio.ToUnityAudioMap(),
                    this.gameObject.AddComponent<AudioSource>(), _soundKey, _volume, _mute, _loop);
#endif

                return;
            }

            _player = _fallbackPlayer switch
            {
#if UNITY_WEBGL && !UNITY_EDITOR
                AudioPlayers.Howl => new HowlAudioPlayer(Id, configuration.Audio.ToHowlAudioMap(),
                    _soundKey,
                    _volume,
                    _mute,
                    _loop),
#endif
#if !UNITY_WEBGL || UNITY_EDITOR
                AudioPlayers.Unity => new UnityAudioPlayer(Id, configuration.Audio.ToUnityAudioMap(),
                    this.gameObject.AddComponent<AudioSource>(),
                    _soundKey,
                    _volume,
                    _mute,
                    _loop),
#endif
                _ => throw new ArgumentOutOfRangeException(nameof(_fallbackPlayer))
            };
            
        }

        public void Play()
        {
            _player.Play();
        }

        public void Stop()
        {
            _player.Stop();
        }

        public void Load() => _player.Load();
        public void SetGlobalMute(bool state) => _player.SetGlobalMute(state);
        public void SetGlobalVolume(float volume) => _player.SetGlobalVolume(volume);

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
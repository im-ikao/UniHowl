using System;
using UniHowl.Domain;
using UniHowl.Spatial;
using UnityEngine;

namespace UniHowl
{
    public class CrossplatformAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioPlayers _fallbackPlayer = AudioPlayers.Howl;

        [SerializeField] private string _soundKey;

        [SerializeField] private float _volume;
        [SerializeField] private bool _loop;
        [SerializeField] private bool _mute;

        [SerializeField] private bool _isSpatial;

        private IAudioPlayer _player;
        private ISpatialAudioSource _spatial;

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
                _loop = value;
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
            Init(AudioConfiguration.GetInstance()); // TODO: FOR USERS WHAT NEED DI, CAN MAKE IT BY DI
        }

        private void Update()
        {
            if (_isSpatial == true )
                _spatial.Update();
        }

        private void Init(AudioConfiguration configuration)
        {
            // TOOD: EJECT TO STRATEGY?
            // TODO: SETUP BY CURRENT AUDIO SOURCE?

            if (Application.isEditor && configuration.Debug)
            {
#if UNITY_EDITOR
                _player = new UnityAudioPlayer(configuration.Audio.ToUnityAudioMap(),
                    this.gameObject.AddComponent<AudioSource>(), _soundKey, _volume, _mute, _loop);

                _spatial = new UnitySpatialPositionSource();
#endif

                return;
            }

            _player = _fallbackPlayer switch
            {
#if UNITY_WEBGL
                AudioPlayers.Howl => new HowlAudioPlayer(configuration.Audio.ToHowlAudioMap(),
                    _soundKey,
                    _volume,
                    _mute,
                    _loop),
#endif
#if !UNITY_WEBGL || UNITY_EDITOR
                AudioPlayers.Unity => new UnityAudioPlayer(configuration.Audio.ToUnityAudioMap(),
                    this.gameObject.AddComponent<AudioSource>(),
                    _soundKey,
                    _volume,
                    _mute,
                    _loop),
#endif
                _ => throw new ArgumentOutOfRangeException(nameof(_fallbackPlayer))
            };

            if (_isSpatial)
            {
                _spatial = _fallbackPlayer switch
                {
#if UNITY_WEBGL
                    AudioPlayers.Howl => new HowlSpatialPositionSource(_player.GetId(), this.transform),
#endif
#if !UNITY_WEBGL || UNITY_EDITOR
                    AudioPlayers.Unity => new UnitySpatialPositionSource(),
#endif
                    _ => throw new ArgumentOutOfRangeException(nameof(_fallbackPlayer))
                };
            }
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
    }
}
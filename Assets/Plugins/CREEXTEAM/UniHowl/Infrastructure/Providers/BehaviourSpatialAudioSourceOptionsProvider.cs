using System;
using System.Collections.Generic;
using UniHowl;
using UniHowl.Domain;
using UnityEngine;

namespace Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers
{
    public class BehaviourSpatialAudioSourceOptionsProvider : MonoBehaviour, ISpatialAudioSourceOptionsProvider
    {
        private Dictionary<AudioPlayers, ISpatialAudioSourceOptions> _options = new();

        private void Awake()
        {
            Scan();
        }

        public void Scan()
        {
            var founded = this.GetComponents<IBehaviourSpatialAudioSourceOptions>();
            foreach (var found in founded)
            {
                var options = found.GetOptions();
                if (_options.ContainsKey(options.FallbackPlayer))
                    continue;
                
                _options.Add(options.FallbackPlayer, options);
            }
        }
        
        public TOptions GetOptions<TOptions>(AudioPlayers player) where TOptions : class, ISpatialAudioSourceOptions
        {
            if (_options.ContainsKey(player) == false)
                throw new ArgumentException();

            return _options[player] as TOptions;
        }
    }
}
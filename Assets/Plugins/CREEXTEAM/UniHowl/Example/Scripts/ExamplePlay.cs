using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.CREEXTEAM.UniHowl.Infrastructure.Providers;
using UniHowl;
using UniHowl.Spatial;
using UnityEngine;
using AudioConfiguration = UniHowl.AudioConfiguration;

public class ExamplePlay : MonoBehaviour
{
    public CrossplatformSpatialAudioSource Audio;
    public BehaviourSpatialAudioSourceOptionsProvider Provider;

    private void Awake()
    {
        Provider.Scan();
        Audio.Init(AudioConfiguration.GetInstance(), Provider);
    }

    private void Start()
    {
        Audio.SetGlobalMute(false);
        Audio.SetGlobalVolume(1);
        Audio.Volume = 1;
        Audio.Loop = true;
        Audio.Mute = false;
        Audio.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Audio.Play();
            Debug.Log("PLAY");
        }
    }
}

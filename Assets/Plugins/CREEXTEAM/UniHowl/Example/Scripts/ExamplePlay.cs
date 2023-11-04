using System;
using System.Collections;
using System.Collections.Generic;
using UniHowl;
using UnityEngine;

public class ExamplePlay : MonoBehaviour
{
    public CrossplatformAudioSource Audio;

    private void Start()
    {
        Audio.SetGlobalMute(false);
        Audio.SetGlobalVolume(1);
        Audio.Volume = 1;
        Audio.Loop = true;
        Audio.Mute = false;
        Audio.Volume = 1;
        Audio.Load();
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

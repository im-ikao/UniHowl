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
        Audio.Volume = 10;
        Audio.Loop = true;
        Audio.Mute = false;
        Audio.Play();
    }
}

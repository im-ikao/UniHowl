using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlay : MonoBehaviour
{
    public CrossplatformAudioSource Audio;

    public void Start()
    {
        Audio.Volume = 10;
        Audio.Loop = true;
        Audio.Play();
        
    }
}

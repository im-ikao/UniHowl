using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _lookAt;
    
    public void Update()
    {
        transform.LookAt(_lookAt);
    }
}

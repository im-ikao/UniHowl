using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerMove : MonoBehaviour
{
    [SerializeField] private int _clamp;
    [SerializeField] private float _speed;
    private int _direction = -1;
    private int _destination;

    public void Awake()
    {
        _destination = _clamp * - 1;
    }

    public void Update()
    {
        if (Math.Abs(_destination - transform.position.z) <= 0.2f)
        {
            _direction *= -1;
            _destination *= -1;
        }

        var position = transform.position;
        var pos = new Vector3(position.x, position.y,
            position.z + _speed * _direction * Time.deltaTime);
        
        transform.position = pos;
    }
}

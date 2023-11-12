using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotateAroundDirection
{
    Left, 
    Right, 
    Up,
    Down,
    LeftUp,
    LeftDown,
    RightUp,
    RightDown,
}

// Usage: Rotate an object around another object without interaction
// Create an object (target)
// Create an object (rotating object)
// Attach this script to the "rotating object"
// Select the direction and the rotation speed
// Enjoy

public class RotateAround : MonoBehaviour
{
    public Transform ToRotateAround;

    [Range(0.0f, 90.0f)]
    public float rotateSpeed = 5.0f;

    public RotateAroundDirection rotateDirection;
    private Vector3 rotationVector;

    void Start()
    {
        if (ToRotateAround)
        {
            switch (rotateDirection)
            {
                case RotateAroundDirection.Left:
                    rotationVector = Vector3.up;
                    break;
                case RotateAroundDirection.Right:
                    rotationVector = Vector3.down;
                    break;
                case RotateAroundDirection.Up:
                    rotationVector = Vector3.right;
                    break;
                case RotateAroundDirection.Down:
                    rotationVector = Vector3.left;
                    break;
                case RotateAroundDirection.LeftUp:
                    rotationVector = Vector3.up + Vector3.right;
                    break;
                case RotateAroundDirection.LeftDown:
                    rotationVector = Vector3.up + Vector3.left;
                    break;
                case RotateAroundDirection.RightUp:
                    rotationVector = Vector3.down + Vector3.right;
                    break;
                case RotateAroundDirection.RightDown:
                    rotationVector = Vector3.down + Vector3.left;
                    break;
                default:
                    rotationVector = Vector3.left;
                    break;
            }
        }
        else
        {
            Debug.LogError("RotateAround has no Transform to rotate around!");
        }
    }

    void Update()
    {
        if (ToRotateAround)
        {
            transform.RotateAround(Vector3.zero, rotationVector, rotateSpeed * Time.deltaTime);
        }
    }
}
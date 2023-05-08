using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float rotateSpeed = 30f; // The speed at which the object will rotate, in degrees per second.

    private void Update()
    {
        // Rotate the object around its Y-axis by the specified speed.
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}

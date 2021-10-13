using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    // how far camera will rotate
    public float lookSensitivity;

    // min and max x look (how far up and down can we look)
    public float minXLook;
    public float maxXLook;

    // camera anchor object
    public Transform cameraAnchor;

    public bool invertXRotation;

    private float currentXRot; // make sure not to go out of range

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Make sure to update after player movement (no jitter)
    private void LateUpdate()
    {
        // Get x and y mouse inputs
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        // rotate player horizontally
        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        // vertical camera tilt
        if(invertXRotation)
            currentXRot += y * lookSensitivity;
        else
            currentXRot -= y * lookSensitivity;

        currentXRot = Mathf.Clamp(currentXRot, minXLook, maxXLook);

        Vector3 clampedAngle = cameraAnchor.eulerAngles;
        clampedAngle.x = currentXRot;
        cameraAnchor.eulerAngles = clampedAngle;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffSet;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    public bool LookAtplayer = false;
    public bool rotateArroundPlayer = true;
    public float RotationSpeed = 5.0f;
    void Start()
    {
        _cameraOffSet = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(rotateArroundPlayer)
        {
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            _cameraOffSet = camTurnAngle * _cameraOffSet;
        }
        Vector3 newPos = PlayerTransform.position + _cameraOffSet;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        if(LookAtplayer || rotateArroundPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}

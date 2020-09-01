using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steerinAngle;
    public bool Driver = false;
    public Transform ExitTarget;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject Camera;
    public BoxCollider EnterTrigger;

    

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle=30;
    public float motorForce = 50;
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steerinAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steerinAngle;
        frontPassengerW.steerAngle = m_steerinAngle;
    }

    private void Accelerate()
    {
        frontDriverW.motorTorque = m_verticalInput * motorForce;
        frontPassengerW.motorTorque = m_verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPoses(frontDriverW, frontDriverT);
        UpdateWheelPoses(frontPassengerW, frontPassengerT);
        UpdateWheelPoses(rearDriverW, rearDriverT);
        UpdateWheelPoses(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPoses(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }


    private void FixedUpdate()
    {
        if (Driver==true)
        {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
            Camera.gameObject.SetActive(true);
            PlayerCamera.gameObject.SetActive(false);
            Player.gameObject.SetActive(false);
            EnterTrigger.gameObject.SetActive(false);
            


            
            if(Input.GetKey(KeyCode.Q))
            {
                Player.gameObject.SetActive(true);
                Camera.gameObject.SetActive(false);
                PlayerCamera.gameObject.SetActive(true);
                EnterTrigger.gameObject.SetActive(true);
                Player.transform.position = ExitTarget.transform.position;
                Driver = false;
            }
        }
    }
}

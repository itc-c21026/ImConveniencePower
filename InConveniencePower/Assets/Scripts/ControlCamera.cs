using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PCテストプレイ用
public class ControlCamera : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    private float miniX = -360f;
    private float maxX = 360f;
    private float miniY = -90f;
    private float maxY = 90f;
    private float rotX = 0f;
    private float rotY = 0f;

    private Quaternion originalRot;
    private float scroll = 0f;
    public float scrollSpeed = 1f;

    private float minFov = 20f;
    private float maxFov = 100f;
    private float originFov;

    void Start()
    {
        originalRot = Camera.main.transform.localRotation;
        originFov = Camera.main.fieldOfView;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rotX -= Input.GetAxis("Mouse X") * mouseSensitivity;
            rotY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            rotX = ClampAngle(rotX, miniX, maxX);
            rotY = ClampAngle(rotY, miniY, maxY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);
            Camera.main.transform.localRotation = originalRot * xQuaternion * yQuaternion;
        }

        scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView -= scroll * scrollSpeed;
        if (Camera.main.fieldOfView < minFov)
        {
            Camera.main.fieldOfView = minFov;
        }
        else if (Camera.main.fieldOfView > maxFov)
        {
            Camera.main.fieldOfView = maxFov;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}

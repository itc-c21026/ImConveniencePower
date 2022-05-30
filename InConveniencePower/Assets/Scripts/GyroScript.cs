using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GyroScript : MonoBehaviour
{
    Transform m_transform;

    readonly Quaternion _BASE_ROTATION = Quaternion.Euler(90, 0, 0);

    private void Awake()
    {
        Screen.SetResolution(1280, 800, false);
    }

    void Start()
    {
        Input.gyro.enabled = true;

        m_transform = transform;
    }

    private void Update()
    {
        // �W���C���̒l���l������
        Quaternion gyro = Input.gyro.attitude;

        // ���M�̉�]���W���C�������ɒ������Đݒ肷��
        m_transform.localRotation = _BASE_ROTATION * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
    }

}

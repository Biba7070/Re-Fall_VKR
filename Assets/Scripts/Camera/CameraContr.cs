using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraContr : MonoBehaviour
{
    public float rotationSpeed;
    public Transform orientation;
    public Transform player;

    [SerializeField] private CinemachineFreeLook cinemVirCam;
    [SerializeField] private float fiOfViMin = 30f;
    [SerializeField] private float fiOfViMax = 70f;

    private float fifOfView = 50f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CamZoom();
        Vector3 lookDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = lookDir.normalized;
    }

    private void CamZoom()
    {
        float fielOdViAmount = 5f;
        if (Input.mouseScrollDelta.y > 0)
        {
            fifOfView -= fielOdViAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            fifOfView += fielOdViAmount;
        }
        fifOfView = Mathf.Clamp(fifOfView, fiOfViMin, fiOfViMax);

        float zoomSpeed = 3f;
        cinemVirCam.m_Lens.FieldOfView = Mathf.Lerp(cinemVirCam.m_Lens.FieldOfView, fifOfView, Time.deltaTime * zoomSpeed);
    }
}


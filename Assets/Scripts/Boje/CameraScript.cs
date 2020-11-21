using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Range(0.2f, 10f)] public float mouseSensitivity = 0.8f;
    public bool mouseLocked = true;
    
    private float maxYAngle = 80f;
    
    private int FPSTarget = 100;
    public new Transform transform;
    public Transform playerTransform;
    private float _xRotation = 0f;

    private void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 50f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 50f * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -maxYAngle, maxYAngle);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPSTarget;
    }

    private void Update()
    {
        if (Application.targetFrameRate != FPSTarget)
            Application.targetFrameRate = FPSTarget;
    }

    private void Start()
    {
        // Rend le curseur invisible et centrée au milieu de la fenetre. ECHAP pour faire réaparaitre le curseur. Modifiable via l'inspector sur la Camera>CameraScript
        if (mouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Range(0.2f, 10f)] public float mouseSensitivity = 0.8f;
    public bool mouseLocked = true;
    
    private float maxYAngle = 80f;
    
    private int FPSTarget = 60;
    private Vector2 _currentRotation;
    public new Transform transform;

    private void FixedUpdate()
    {
        _currentRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity * 50f * Time.deltaTime;
        _currentRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity * 50f * Time.deltaTime;
        _currentRotation.x = Mathf.Repeat(_currentRotation.x, 360);
        _currentRotation.y = Mathf.Clamp(_currentRotation.y, -maxYAngle, maxYAngle);
        transform.rotation = Quaternion.Euler(_currentRotation.y, _currentRotation.x, 0);
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

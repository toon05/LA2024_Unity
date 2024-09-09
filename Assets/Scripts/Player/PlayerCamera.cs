using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    private const float MouseSensitivity = 5f;
    private const float MaxAngle = 45f;
    private const float MinAngle = 0f;

    private float currentAngle = 0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mouseInputX) > 0.001f)
        {
            mainCamera.transform.RotateAround(transform.position, Vector3.up, mouseInputX * MouseSensitivity);
        }

        if (Mathf.Abs(mouseInputY) > 0.001f)
        {
            float newAngle = currentAngle + mouseInputY * MouseSensitivity;
            if (newAngle < MaxAngle && newAngle > MinAngle)
            {
                mainCamera.transform.RotateAround(transform.position, mainCamera.transform.right, mouseInputY * MouseSensitivity);
                currentAngle = newAngle;
            }
        }
    }
}
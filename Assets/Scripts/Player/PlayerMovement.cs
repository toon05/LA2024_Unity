using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject playerModel;
    private const float MoveSpeed = 2f;
    
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(mainCamera.transform.right, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;
        transform.position += moveDirection * Time.deltaTime * MoveSpeed;
        
        if (moveDirection != Vector3.zero)
        {
            playerModel.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, 2, -5); 
    public float rotationSpeed = 2f; 

    private float currentRotationX = 0f; 

    void LateUpdate()
    {
       
        if (Input.GetMouseButton(1)) 
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            currentRotationX += mouseX;
        }

        
        Quaternion rotation = Quaternion.Euler(0, currentRotationX, 0);
        transform.position = player.position + rotation * offset;

        
        transform.LookAt(player.position);
    }
}

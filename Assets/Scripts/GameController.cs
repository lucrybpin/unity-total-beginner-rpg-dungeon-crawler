using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, 4.1f))
            {
                cameraTransform.position += 4 * cameraTransform.forward;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.Raycast(cameraTransform.position, -cameraTransform.forward, out RaycastHit hit, 4.1f))
            {
                cameraTransform.position -= 4 * cameraTransform.forward;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            cameraTransform.rotation *= Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            cameraTransform.rotation *= Quaternion.Euler(0f, 90f, 0f);
        }
    }
}

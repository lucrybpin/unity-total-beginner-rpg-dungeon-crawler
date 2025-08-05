using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 4f, Color.green, 2f);

        if (Input.GetKeyDown(KeyCode.W))
        {
            cameraTransform.position += 4 * cameraTransform.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            cameraTransform.position -= 4 * cameraTransform.forward;
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

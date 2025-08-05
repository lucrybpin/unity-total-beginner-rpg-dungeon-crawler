using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
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
            // We cannot do:
            // rotation += Quaternion.Euler(0f, -90f, 0f);

            // Because tha nature of quaternions, but imagine that
            // sum of quaternions are multiplication, so we can do:
            cameraTransform.rotation *= Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            cameraTransform.rotation *= Quaternion.Euler(0f, 90f, 0f);
        }
    }
}

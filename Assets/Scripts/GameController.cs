using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform cameraTransform;

    public EndOfDungeon endOfDungeon;
    public GameObject canvasEndOfGame;

    void Start()
    {
        Physics.queriesHitTriggers = false;
        endOfDungeon.OnEnterEndOfDungeon += EndGame;
    }

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

    void EndGame()
    {
        canvasEndOfGame.SetActive(true);
    }

    public void CloseGame()
    {
        Debug.Log($">>>> Close Game Clicked");
        Application.Quit();
    }

}

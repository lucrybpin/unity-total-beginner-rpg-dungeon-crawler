using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public EndOfDungeon endOfDungeon;
    public GameObject canvasEndOfGame;

    private bool gameFinished = false;

    void Start()
    {
        Physics.queriesHitTriggers = false;
        endOfDungeon.OnEnterEndOfDungeon += EndGame;
    }

    void Update()
    {
        if(!gameFinished)
            playerController.Move();
    }

    void EndGame()
    {
        canvasEndOfGame.SetActive(true);
        gameFinished = true;
    }

    public void CloseGame()
    {
        Debug.Log($">>>> Close Game Clicked");
        Application.Quit();
    }

}

using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public Skeleton skeleton;
    public EndOfDungeon endOfDungeon;
    public GameObject canvasEndOfGame;
    public GameObject canvasDieEndGame;

    private bool gameFinished = false;

    void Start()
    {
        Physics.queriesHitTriggers = false;
        endOfDungeon.OnEnterEndOfDungeon += EndGame;
        playerController.OnPlayerDie += DieEndGame;

        playerController.Initialize(10);
        skeleton.Initialize(100);
    }

    void Update()
    {
        if (!gameFinished)
        {
            playerController.Move();
            playerController.Attack();

            skeleton.Attack();
        }
    }

    void EndGame()
    {
        canvasEndOfGame.SetActive(true);
        gameFinished = true;
    }

    void DieEndGame()
    {
        canvasDieEndGame.SetActive(true);
        gameFinished = true;
    }

    public void CloseGame()
    {
        Debug.Log($">>>> Close Game Clicked");
        Application.Quit();
    }

}

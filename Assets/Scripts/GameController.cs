using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public Skeleton skeleton;
    public EndOfDungeon endOfDungeon;
    public GameObject canvasEndOfGame;

    private bool gameFinished = false;

    void Start()
    {
        Physics.queriesHitTriggers = false;
        endOfDungeon.OnEnterEndOfDungeon += EndGame;

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

    public void CloseGame()
    {
        Debug.Log($">>>> Close Game Clicked");
        Application.Quit();
    }

}

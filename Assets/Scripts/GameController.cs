using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public Skeleton skeleton;
    public EndOfDungeon endOfDungeon;
    public SwordTrigger swordTrigger;
    public GameObject canvasEndOfGame;
    public GameObject canvasDieEndGame;

    private bool gameFinished = false;

    void Start()
    {
        Physics.queriesHitTriggers = false;
        endOfDungeon.OnEnterEndOfDungeon += EndGame;
        playerController.OnPlayerDie += DieEndGame;
        swordTrigger.OnSwordFound += AddSwordToPlayer;

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

    void AddSwordToPlayer()
    {
        swordTrigger.gameObject.SetActive(false);
        playerController.EquipSword();
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

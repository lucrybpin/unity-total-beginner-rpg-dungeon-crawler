using System;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public Skeleton skeleton;
    public EndOfDungeon endOfDungeon;
    public SwordTrigger swordTrigger;
    public CutsceneTrigger cutsceneTrigger;
    public GameObject canvasEndOfGame;
    public GameObject canvasDieEndGame;
    public PlayableDirector playableDirector;

    private bool gameFinished = false;

    void Start()
    {
        Physics.queriesHitTriggers = false;
        endOfDungeon.OnEnterEndOfDungeon += EndGame;
        playerController.OnPlayerDie += DieEndGame;
        swordTrigger.OnSwordFound += AddSwordToPlayer;
        cutsceneTrigger.OnTriggerEnterCutscene += StartCutscene;

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

    private void StartCutscene()
    {
        cutsceneTrigger.gameObject.SetActive(false);
        playableDirector.Play();
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

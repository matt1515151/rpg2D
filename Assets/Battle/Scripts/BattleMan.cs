using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    PlayerInput,
    EnemyTurn,
    End
}

public class BattleMan : MonoBehaviour
{
    public BattleState state;

    [SerializeField] GameObject[] playerTeamPrefabs;
    [SerializeField] GameObject[] enemyTeamPrefabs;

    List<Entity> playerTeam = new();
    List<Entity> enemyTeam = new();

    private void Start()
    {
        state = BattleState.Start;

        SetupBattle();
    }

    void SetupBattle()
    {

        // spawn everything
        int x = 0; 
        foreach (GameObject e in playerTeamPrefabs)
        {
            playerTeam.Add(Instantiate<GameObject>(e).GetComponent<Entity>());
            playerTeam[x].Setup(Team.Left);
            x++;
        }
        x = 0;
        foreach (GameObject e in enemyTeamPrefabs)
        {
            enemyTeam.Add(Instantiate<GameObject>(e).GetComponent<Entity>());
            enemyTeam[x].Setup(Team.Right);
            x++;
        }

        // play some intro animations

        StartCoroutine(StartPlayerTurn());
    }

    IEnumerator StartPlayerTurn()
    {
        state = BattleState.PlayerTurn;
        Debug.Log("player's turn starts");
        yield return new WaitForSeconds(2);
    }

    IEnumerator PlayerAction(int whatever)
    {
        if (state == BattleState.PlayerTurn)
        {
            state = BattleState.PlayerInput;
            // perform the move
            Debug.Log("player presses button " + whatever);

            playerTeam[0].Attack(enemyTeam[0], playerTeam[0].entityBase.statATK);

            yield return new WaitForSeconds(2);
            StartCoroutine(StartEnemyTurn());
        }
    }

    IEnumerator StartEnemyTurn()
    {
        state = BattleState.EnemyTurn;
        Debug.Log("enemy fuckin does something");

        enemyTeam[0].Attack(playerTeam[0], enemyTeam[0].entityBase.statATK);

        yield return new WaitForSeconds(4);
        StartCoroutine(StartPlayerTurn());
    }

    public void ButtonPress(int whatever)
    {
        StartCoroutine(PlayerAction(whatever));
    }
}
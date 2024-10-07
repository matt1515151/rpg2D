using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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


        StartPlayerTurn();
    }

    void StartPlayerTurn()
    {
        state = BattleState.PlayerTurn;
        // recieve input
        state = BattleState.PlayerInput;

        StartEnemyTurn();
    }

    void StartEnemyTurn()
    {
        state = BattleState.EnemyTurn;
    }
}
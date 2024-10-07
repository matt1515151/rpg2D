
using System.Collections;
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

    Entity[] playerTeam;
    Entity[] enemyTeam;

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
            GameObject temp = Instantiate<GameObject>(e);
            playerTeam[x] = temp.GetComponent<Entity>();
            playerTeam[x].Setup(Team.Left);
            x++;
        }
        x = 0;
        foreach (GameObject e in enemyTeamPrefabs)
        {
            enemyTeam[x] = Instantiate<GameObject>(e).GetComponent<Entity>();
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
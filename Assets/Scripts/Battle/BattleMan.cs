
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

    [SerializeField] Entity[] playerTeam;
    [SerializeField] Entity[] enemyTeam;

    private void Start()
    {
        state = BattleState.Start;

        SetupBattle();
    }

    void SetupBattle()
    {
        foreach (Entity e in playerTeam)
        {
            Instantiate<GameObject>(e.gameObject);
            e.Setup(Team.Left);
        }
        foreach (Entity e in enemyTeam)
        {
            Instantiate<GameObject>(e.gameObject);
            e.Setup(Team.Right);
        }

        StartPlayerTurn();
    }

    void StartPlayerTurn()
    {
        // start of turn effects
        state = BattleState.PlayerTurn;
    }
}

using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    End
}

public class BattleMan : MonoBehaviour
{
    public BattleState state;

    private void Start()
    {
        state = BattleState.Start;

        SetupBattle();
    }

    void SetupBattle()
    {
        // idfk
    }
}
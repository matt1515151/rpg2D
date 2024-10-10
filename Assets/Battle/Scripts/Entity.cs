using UnityEngine;
using System;

public enum Team
{
    Left = -1,
    Right = 1
}

public class Entity : MonoBehaviour
{
    public Team team;

    // every entity behaviour script
    public EntityUI entityUI;
    public EntityBase entityBase;
    public EntityAnimator entityAnimator;
    public EntityAudio entityAudio;
    [Space]
    public GameObject[] cards = new GameObject[4];

    [SerializeField]BattleMan battleMan;

    public void Setup(Team team)
    {
        battleMan = FindFirstObjectByType<BattleMan>();

        // idiot check
        if(!TryGetComponent<EntityBase>(out entityBase))
        { throw new Exception(name + " is missing an EntityBase!"); }
        if(!TryGetComponent<EntityUI>(out entityUI))
        { throw new Exception(name + " is missing an EntityUI!"); }
        if (!TryGetComponent<EntityAnimator>(out entityAnimator))
        { throw new Exception(name + " is missing an EntityAnimator!"); }
        if (!TryGetComponent<EntityAudio>(out entityAudio))
        { throw new Exception(name + " is missing an EntityAudio!"); }

        // set its team
        this.team = team;

        // put me in my grave
        // i mean place
        transform.position = new Vector2(5f * (int) team, 0f);

        // initialise health value
        entityBase.currentHP = entityBase.statHP;

        entityUI.SetupUI();

        entityAnimator.SetupSprite();
    }

    public void Attack(Entity target, int damage)
    {
        // go to target
        // play attack animation
        target.entityBase.TakeDamage(damage);
    }

    public void Heal(int healAmount)
    {
        // play heal animation
        entityBase.Heal(healAmount);
    }
}

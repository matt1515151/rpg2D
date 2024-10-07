using UnityEngine;
using TMPro;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;

public enum Team
{
    Left,
    Right
}

public class Entity : MonoBehaviour
{
    public Team team;

    // every entity behaviour script
    public EntityUI entityUI;
    public EntityBase entityBase;
    public EntityAnimator entityAnimator;
    public EntityAudio entityAudio;

    public void Setup(Team team)
    {
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

        entityUI.SetupUI();

        entityAnimator.SetupSprite();

        // put me in my grave
        // i mean place
        switch (team)
        {
            case Team.Left:
                transform.position = new Vector3(-5f, 0f);
                break;
            case Team.Right:
                transform.position = new Vector3(5f, 0f);
                break;
        }

        // initialise health value
        entityBase.currentHP = entityBase.statHP;
    }

    public void DebugTest()
    {
        Debug.Log("test successful lmao");
    }
}

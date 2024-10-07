using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using static UnityEngine.EventSystems.EventTrigger;

public class EntityUI : MonoBehaviour
{
    // this script is used exclusively for managing the ui

    // prefabs
    public GameObject statsUI;
    public GameObject buttons;
    [Space]
    // ui placement adjustments
    public float statUIoffset = 1.5f;
    public float buttonsOffset = -2f;

    [SerializeField] StatsUI entityStatsUI;

    // the parent entity, shortened to E for ease of use :3
    [SerializeField] Entity entity;

    public void Awake()
    {
        entity = GetComponent<Entity>();
    }

    public void SetupUI()
    {
        // THIS DOESNT FUCKING WORK AND I DONT KNOW HOW TO FIX IT
        // todo: rework

        // create a stat display
        entityStatsUI = Instantiate<GameObject>(statsUI,
            transform.position + new Vector3(0f, statUIoffset),
            Quaternion.identity).GetComponent<StatsUI>();

        entity.DebugTest();

        UpdateStats();
    }

    public void UpdateStats()
    {
        // put the stats in the texts
        entityStatsUI.SetHealth(entity.entityBase.currentHP, entity.entityBase.statHP);
        entityStatsUI.SetName(entity.entityBase.entityName);
        entityStatsUI.SetAttack(entity.entityBase.statATK);
    }
}

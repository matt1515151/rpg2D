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
    public float statUIoffset = 2.5f;
    public float buttonsOffset = -2f;

    StatsUI entityStatsUI;

    // the parent entity, shortened to E for ease of use :3
    Entity E;

    public void Awake()
    {
        E = GetComponent<Entity>();
    }

    public void SetupUI()
    {
        // create a stat display
        entityStatsUI = Instantiate<GameObject>(statsUI,
            transform.position + new Vector3(0f, statUIoffset),
            Quaternion.identity).GetComponent<StatsUI>();

        UpdateStats();
    }

    public void UpdateStats()
    {
        // put the stats in the texts
        entityStatsUI.SetHealth(E.entityBase.currentHP, E.entityBase.statHP);
        entityStatsUI.SetName(E.entityBase.entityName);
        entityStatsUI.SetAttack(E.entityBase.statATK);
    }
}

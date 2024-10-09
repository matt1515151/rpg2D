using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    // this script is used exclusively for managing stats

    public int statHP, statATK, statDEF, currentHP;
    public string entityName;

    // the parent entity, shortened to E for ease of use :3
    Entity E;

    private void Start()
    {
        E = GetComponent<Entity>();
    }


    public void Heal(int healAmount)
    {
        currentHP += healAmount;
        // no overflowing hp values >:(
        if(currentHP >= statHP)
        {
            currentHP = statHP;
        }

        E.entityUI.UpdateStats();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        E.entityUI.UpdateStats();

        if (currentHP <= 0)
        {
            currentHP = 0;

            // death thingy
        }
    }
}

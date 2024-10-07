using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    // this script is used exclusively for managing stats

    public int statHP, statATK, statDEF, currentHP;
    public string entityName;

    public Sprite sprite;

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
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP += damageAmount;

        if (currentHP <= 0)
        {
            currentHP = 0;

            // death thingy
        }
    }
}

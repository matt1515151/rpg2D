using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public TextMeshPro healthUI, nameUI, atkUI;

    private void Awake()
    {
        if(!transform.Find("health").TryGetComponent<TextMeshPro>(out healthUI))
        {
            Debug.Log("nope");
        }
        nameUI = transform.Find("name").GetComponent<TextMeshPro>();
        atkUI = transform.Find("atk").GetComponent<TextMeshPro>();
    }

    public void SetHealth(int health, int maxHealth)
    {
        healthUI.text = health + " / " + maxHealth;
    }
    public void SetName(string name)
    {
        nameUI.text = name;
    }
    public void SetAttack(int attack)
    {
        atkUI.text = "atk: " + attack;
    }
}

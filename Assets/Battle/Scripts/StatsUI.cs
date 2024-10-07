using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public TextMeshProUGUI healthUI, nameUI, atkUI;

    private void Start()
    {
        healthUI = transform.Find("health").GetComponent<TextMeshProUGUI>();
        nameUI = transform.Find("name").GetComponent<TextMeshProUGUI>();
        atkUI = transform.Find("atk").GetComponent<TextMeshProUGUI>();
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

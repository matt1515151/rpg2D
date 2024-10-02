using UnityEngine;
using TMPro;
using System;

public enum Team
{
    Left,
    Right
}

public class Entity : MonoBehaviour
{
    public GameObject statsUI;
    public GameObject buttons;
    [Space]
    public string entityName;
    [Space]
    public int statHP;
    public int statATK;
    [Space]
    public float statUIoffset = 1.5f;
    public float buttonsOffset = -60f;

    [SerializeField]
    Team team;
    GameObject entityStats;
    TextMeshProUGUI healthUI;
    TextMeshProUGUI atkUI;
    TextMeshProUGUI nameUI;
    int health;

    public void Setup(Team team)
    {
        // set its team
        this.team = team;
        // put me in my grave
        // i mean place
        switch (team)
        {
            case Team.Left:
                transform.position = new Vector3(-5f, 0f);
                CreateButtons();
                break;
            case Team.Right:
                transform.position = new Vector3(5f, 0f);
                break;
        }

        // initialise health value
        health = statHP;
        // create a stat display
        entityStats = Instantiate(statsUI,
            transform.position + new Vector3(0f, statUIoffset),
            Quaternion.Euler(0f,0f,0f),
            FindFirstObjectByType<Canvas>().transform);
        // get the stat display text items
        healthUI = entityStats.transform.Find("health").GetComponent<TextMeshProUGUI>();
        atkUI = entityStats.transform.Find("atk").GetComponent<TextMeshProUGUI>();
        nameUI = entityStats.transform.Find("name").GetComponent<TextMeshProUGUI>();
        // put the stats in the texts
        healthUI.text = health + " / " + statHP;
        atkUI.text = "atk: " + statATK;
        nameUI.text = entityName;
    }

    public void Damage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;

        if(health > statHP)
        {
            health = statHP;
        }
    }

    void Die()
    {
        // play animation
        // ;)
        // KILL
        Destroy(gameObject);
    }

    void CreateButtons()
    {
        Instantiate(buttons, transform.position + new Vector3(0f, buttonsOffset), Quaternion.Euler(0f, 0f, 0f), FindFirstObjectByType<Canvas>().transform);
    }
}

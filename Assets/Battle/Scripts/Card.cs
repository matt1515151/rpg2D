using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    Entity E;
    public string cardName;
    public Sprite sprite;

    public void SetupCard(Entity entity)
    {
        E = entity;
        Debug.Log(cardName + " has been setup");
    }
}

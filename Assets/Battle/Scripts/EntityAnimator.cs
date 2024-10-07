using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    // this script is used exclusively for managing animations and sprites

    SpriteRenderer spriteRenderer;
    public Sprite sprite;


    Entity E;

    private void Awake()
    {
        E = GetComponent<Entity>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetupSprite()
    {
        spriteRenderer.sprite = sprite;
        switch(E.team)
        {
            case Team.Left:
                GetComponent<SpriteRenderer>().flipX = false;
                break;
            case Team.Right:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
        }
    }
}

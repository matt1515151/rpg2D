using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    // this script is used exclusively for managing animations and sprites

    SpriteRenderer spriteRenderer;
    public Sprite sprite;

    Animator animator;

    // the parent entity, shortened to E for ease of use :3
    Entity E;

    private void Awake()
    {
        E = GetComponent<Entity>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

    public void PlayAnimation(string animation)
    {
        animator.SetTrigger(animation);
    }
}

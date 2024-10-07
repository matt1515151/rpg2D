using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    // this script is used exclusively for managing animations and sprites
    Entity E;

    private void Start()
    {
        E = GetComponent<Entity>();
    }
}

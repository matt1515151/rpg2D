using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAudio : MonoBehaviour
{
    // this script is used exclusively for managing sounds

    Entity E;

    private void Start()
    {
        E = GetComponent<Entity>();
    }
}

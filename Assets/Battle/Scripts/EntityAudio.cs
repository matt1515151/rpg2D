using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAudio : MonoBehaviour
{
    // this script is used exclusively for managing sounds

    // the parent entity, shortened to E for ease of use :3
    Entity E;

    private void Start()
    {
        E = GetComponent<Entity>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBase : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = player.transform.position;
    }
}

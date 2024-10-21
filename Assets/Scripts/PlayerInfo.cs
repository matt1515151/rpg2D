using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public bool hasHook = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public SceneChanger sceneChanger;
    private void Awake()
    {
        sceneChanger = FindFirstObjectByType<SceneChanger>();

        SpawnPoint[] spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        foreach(SpawnPoint s in spawnPoints)
        {
            if(s.spawnPointID == sceneChanger.targetSpawnPoint)
            {
                transform.position = s.transform.position;
            }
        }
    }
}

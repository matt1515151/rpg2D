using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnPointID;

    private void OnDrawGizmos()
    {
        Vector2 pos = transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(pos.x - 0.5f, pos.y + 1), new Vector2(pos.x + 0.5f, pos.y + 1));
        Gizmos.DrawLine(new Vector2(pos.x - 0.5f, pos.y + 1), new Vector2(pos.x + 0, pos.y));
        Gizmos.DrawLine(new Vector2(pos.x + 0.5f, pos.y + 1), new Vector2(pos.x + 0, pos.y));
    }
}

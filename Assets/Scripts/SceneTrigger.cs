using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    SceneChanger sceneChanger;
    public int changeToScene;
    public int targetSpawn;
    public int animID = 0;

    public BoxCollider2D boxCollider;

    private void Awake()
    {
        sceneChanger = FindFirstObjectByType<SceneChanger>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneChanger.ChangeScene(changeToScene, targetSpawn, animID);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + boxCollider.offset, boxCollider.size);
    }
}

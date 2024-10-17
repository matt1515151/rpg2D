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
    Rect cr;

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
        cr.size = boxCollider.size;
        cr.position = (Vector2)transform.position + boxCollider.offset - new Vector2(cr.size.x / 2, cr.size.y / 2);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(cr.xMin, cr.yMin), new Vector3(cr.xMax, cr.yMin));
        Gizmos.DrawLine(new Vector3(cr.xMin, cr.yMin), new Vector3(cr.xMin, cr.yMax));
        Gizmos.DrawLine(new Vector3(cr.xMin, cr.yMax), new Vector3(cr.xMax, cr.yMax));
        Gizmos.DrawLine(new Vector3(cr.xMax, cr.yMin), new Vector3(cr.xMax, cr.yMax));
    }
}

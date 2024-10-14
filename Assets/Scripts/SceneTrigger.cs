using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    SceneChanger sceneChanger;
    public string changeToScene;
    public int targetSpawn;

    private void Awake()
    {
        sceneChanger = FindFirstObjectByType<SceneChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sceneChanger.ChangeScene(changeToScene, targetSpawn);
        }
    }
}

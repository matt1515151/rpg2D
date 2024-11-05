using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public int deathSceneAnim;
    SpawnPoint[] spawnPoints;

    private void Awake()
    {
        transform.Find("hook").Find("Gun").GetComponent<SpriteRenderer>().enabled = FindAnyObjectByType<PlayerInfo>().hasHook;

        sceneChanger = FindFirstObjectByType<SceneChanger>();

        spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        GoToSpawn();
    }

    void GoToSpawn()
    {
        foreach (SpawnPoint s in spawnPoints)
        {
            if (s.spawnPointID == sceneChanger.targetSpawnPoint)
            {
                transform.position = s.transform.position;
            }
        }
    }

    // this part handles dying (duh)
    public IEnumerator Die()
    {
        // STOP MOVING YOU'RE DEAD
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // play falling over animation + disable hook
        transform.Find("hook").gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("Dead");
        yield return new WaitForSeconds(0.5f);

        // animate to black
        sceneChanger.PlayAnimation("in", deathSceneAnim);
        yield return new WaitForSeconds(1f);

        // move player + camera back to spawn
        GoToSpawn();
        Camera.main.GetComponent<CameraFollow>().InstantMove();

        // animate back to scene
        sceneChanger.PlayAnimation("out", deathSceneAnim);

        // back to normal
        transform.Find("hook").gameObject.SetActive(true);
        GetComponent<PlayerMovement>().enabled = true;
    }
}

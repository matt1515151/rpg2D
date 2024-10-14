using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetSpawnPoint = 0;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName, int targetSpawn)
    {
        SceneManager.LoadScene(sceneName);
        targetSpawnPoint = targetSpawn;
    }
    public void Exit()
    {
        // If we are in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // If we are in a standalone build
#else
           Application.Quit();
#endif
    }
}
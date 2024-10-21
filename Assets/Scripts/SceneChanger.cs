using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public int targetSpawnPoint = 0;
    public float fadeTime = 1f;
    [Space]
    public AnimatorOverrideController[] animOverrides;
    [HideInInspector] public bool isAnimating;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(int sceneIndex, int targetSpawn, int animID)
    {
        StartCoroutine(LoadScene(sceneIndex, animID));
        targetSpawnPoint = targetSpawn;
    }

    IEnumerator LoadScene(int sceneIndex, int animID)
    {
        isAnimating = true;

        animator.runtimeAnimatorController = animOverrides[animID];
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(sceneIndex);
        transform.Find("fade").GetComponent<Animator>().SetTrigger("End");

        isAnimating = false;
    }

    public void StartButton()
    {
        ChangeScene(1, 0, 2);
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
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneSkip : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int skipScene;
    public int skipSpawn;
    public GameObject skipButtons;

    int skipUnlock = 0;
    SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = FindAnyObjectByType<SceneChanger>();

        List<string> options = new();
        foreach(AnimatorOverrideController i in sceneChanger.animOverrides)
        {
            options.Add(i.name);
        }

        dropdown.AddOptions(options);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            skipUnlock++;
            if(skipUnlock == 3)
            {
                Debug.Log("ultimat hax0r mode enabled B)");

                skipButtons.SetActive(true);
            }
        }
    }

    public void SkipScene()
    {
        skipScene = Convert.ToInt32(transform.Find("Skip Button").Find("scene id").GetComponent<TMP_InputField>().text);
        skipSpawn = Convert.ToInt32(transform.Find("Skip Button").Find("spawnpoinr").GetComponent<TMP_InputField>().text);

        sceneChanger.ChangeScene(skipScene, skipSpawn, dropdown.value);
    }

    public void EnableHook()
    {
        FindAnyObjectByType<PlayerInfo>().hasHook = true;
    }
}

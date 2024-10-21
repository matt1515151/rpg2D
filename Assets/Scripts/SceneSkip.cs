using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneSkip : MonoBehaviour
{
    System.Random rand = new();
    public TMP_Dropdown dropdown;
    public int skipScene;

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

    public void SkipScene()
    {
        skipScene = Convert.ToInt32(transform.Find("Skip Button").Find("Input").GetComponent<TMP_InputField>().text);

        Debug.Log("skipping to scene " + skipScene);
        sceneChanger.ChangeScene(skipScene, 0, dropdown.value);
    }

    public void EnableHook()
    {
        FindAnyObjectByType<PlayerInfo>().hasHook = true;
    }
}

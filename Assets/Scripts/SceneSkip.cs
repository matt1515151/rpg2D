using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneSkip : MonoBehaviour
{
    public int skipScene;

    public void SkipScene()
    {
        skipScene = Convert.ToInt32(transform.Find("Skip Button").Find("Input").GetComponent<TMP_InputField>().text);

        Debug.Log("skipping to scene " + skipScene);
        FindAnyObjectByType<SceneChanger>().ChangeScene(skipScene, 0, 0);
    }
}

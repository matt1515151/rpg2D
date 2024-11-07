using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class test : MonoBehaviour
{
    public Shader shader;

    public float multiplier, threshold, size;

    public bool flipX, flipY;

    public Color color;

    public float squish;

    Material material;

    private void OnEnable()
    {
        material = new Material(shader);
        material.hideFlags = HideFlags.HideAndDontSave;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_Multiplier", multiplier);
        material.SetFloat("_Threshold", threshold / 2);
        material.SetFloat("_Size", size / 2);

        material.SetFloat("_YFlip", flipY ? 1 : 0);
        material.SetFloat("_XFlip", flipX ? 1 : 0);

        material.SetVector("_Color", color);

        material.SetFloat("_SquishAmount", squish);

        var temp = RenderTexture.GetTemporary(source.width, source.height, 0);

        Graphics.Blit(source, temp, material, 0);
        Graphics.Blit(temp, destination, material, 1);

        RenderTexture.ReleaseTemporary(temp);
    }

    private void OnDisable()
    {
        material = null;
    }
}

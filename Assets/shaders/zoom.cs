using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class zoom : MonoBehaviour
{
    public Shader shader;

    public Vector2 zoomAmount;
    public Vector2 offset;

    Material material;

    private void OnEnable()
    {
        material = new Material(shader);
        material.hideFlags = HideFlags.HideAndDontSave;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetVector("_Offset", offset);
        material.SetVector("_ZoomAmount", zoomAmount);

        Graphics.Blit(source, destination, material);
    }

    private void OnDisable()
    {
        material = null;
    }
}

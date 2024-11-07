using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class pixelate : MonoBehaviour
{
    public Shader shader;

    public int amount;
    [Range(0.0f, 1.0f)]
    public float upperThreshold;
    [Range(0.0f, 1.0f)]
    public float lowerThreshold;

    public bool pixelated;
    public bool greyscale;

    Material material;

    private void OnEnable()
    {
        material = new Material(shader);
        material.hideFlags = HideFlags.HideAndDontSave;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_Amount", amount);
        material.SetFloat("_UpperThreshold", upperThreshold);
        material.SetFloat("_LowerThreshold", lowerThreshold);
        material.SetFloat("_Pixelate", pixelated ? 1: 0);
        material.SetFloat("_Greyscale", greyscale ? 1 : 0);

        Graphics.Blit(source, destination, material);
    }

    private void OnDisable()
    {
        material = null;
    }
}

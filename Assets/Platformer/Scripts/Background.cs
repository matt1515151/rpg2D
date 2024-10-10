using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Camera cam;

    void LateUpdate()
    {
        transform.position = cam.transform.position;
        transform.position += new Vector3(0f, 0f, 10f);
    }
}

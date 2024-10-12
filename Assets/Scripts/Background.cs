using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Camera cam;

    void LateUpdate()
    {
        // putting it in late update reduces jitteriness
        transform.position = cam.transform.position;
        transform.position += new Vector3(0f, 0f, 10f);
    }
}

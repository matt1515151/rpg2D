using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    void Update()
    {
        Vector3 movement = (followTarget.position - transform.position) * 0.7f;
        transform.position += movement;
        transform.position += new Vector3(0f,0f,-10f);
    }
}

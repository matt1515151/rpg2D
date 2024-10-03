using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;

    public float camSpeed = 0.5f;
    public float yOffset = 2f;
    public float deadZone = 1f;

    void Update()
    {
        Vector3 diff = followTarget.position - transform.position;

        diff.y += yOffset;
        diff.z = 0f;

        if (diff.magnitude > deadZone)
        {
            diff *= Time.deltaTime * Mathf.Sqrt(diff.magnitude) * camSpeed;
            transform.position += diff;
        }
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    [Space]
    public float camSpeed = 0.5f;
    public float yOffset = 2f;
    public float deadZone = 1f;

    void Update()
    {
        Vector2 diff = followTarget.position - transform.position;

        diff.y += yOffset;

        if (diff.magnitude > deadZone)
        {
            diff *= Mathf.Sqrt(diff.magnitude - deadZone) * camSpeed;
            diff *= Time.deltaTime;
            transform.position += (Vector3)diff;
        }

    }
}

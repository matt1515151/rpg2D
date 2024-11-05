using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    [Space]
    public float camSpeed = 0.5f;
    public Vector2 Offset = new(0f, 0f);    // offset from target
    public float deadZone = 1f;   // camera wont move within this range of its target
    [Range(0f, 1f)]
    public float mouseMoveAmount = 0.5f; // how much the mouse should move the camera by
    public float maxMouseMove = 6f;      // the furthest that the mouse will move the camera

    public Rect cameraBounds;                   // the camera cannot move beyond these values
    public Vector2 cameraSize = new(18f, 10f);  // probably dont change

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos -= (Vector2)transform.position;
        mousePos *= mouseMoveAmount;
        mousePos = Vector2.ClampMagnitude(mousePos, maxMouseMove);
        
        Vector2 diff = followTarget.position - transform.position;

        diff += Offset;
        diff += mousePos;

        if (diff.magnitude > deadZone)
        {
            // applies quadratic(?) scaling to the camera's speed based on distance
            diff *= Mathf.Sqrt(diff.magnitude - deadZone) * camSpeed;
            diff *= Time.deltaTime;
            transform.position += (Vector3)diff;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,
            cameraBounds.xMin + cameraSize.x / 2,
            cameraBounds.xMax - cameraSize.x / 2),

            Mathf.Clamp(transform.position.y,
            cameraBounds.yMin + cameraSize.y / 2,
            cameraBounds.yMax - cameraSize.y / 2),

            -10f);
    }

    private void OnDrawGizmos()
    {
        // hehe funny box
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(cameraBounds.center, cameraBounds.size);
    }

    private void Start()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, -10f);
    }

    // for respawning, mainly
    public void InstantMove()
    {
        transform.position = followTarget.position;
    }
}

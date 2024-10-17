using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    [Space]
    public float camSpeed = 0.5f;
    public float yOffset = 2f;    // push the camera above or below its target
    public float deadZone = 1f;   // camera wont move within this range of its target
    [Range(0f, 1f)]
    public float mouseMoveAmount = 0.5f; // how much the mouse should move the camera by
    public float maxMouseMove = 6f;      // the furthest that the mouse will move the camera

    public Rect cameraBounds;
    public Vector2 cameraSize = new(18f, 10f);

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos -= (Vector2)transform.position;
        mousePos *= mouseMoveAmount;
        mousePos = Vector2.ClampMagnitude(mousePos, maxMouseMove);
        
        Vector2 diff = followTarget.position - transform.position;

        diff.y += yOffset;
        diff += mousePos;

        if (diff.magnitude > deadZone)
        {
            // applies quadratic(?) scaling to the camera's speed based on distance
            diff *= Mathf.Sqrt(diff.magnitude - deadZone) * camSpeed;
            diff *= Time.deltaTime;
            transform.position += (Vector3)diff;
        }

        Vector2 cameraView = new(
            Camera.main.orthographicSize,
            Camera.main.orthographicSize * Screen.width / Screen.height
            );

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
        Gizmos.DrawLine(new Vector3(cameraBounds.xMin, cameraBounds.yMin), new Vector3(cameraBounds.xMax, cameraBounds.yMin));
        Gizmos.DrawLine(new Vector3(cameraBounds.xMin, cameraBounds.yMin), new Vector3(cameraBounds.xMin, cameraBounds.yMax));
        Gizmos.DrawLine(new Vector3(cameraBounds.xMin, cameraBounds.yMax), new Vector3(cameraBounds.xMax, cameraBounds.yMax));
        Gizmos.DrawLine(new Vector3(cameraBounds.xMax, cameraBounds.yMin), new Vector3(cameraBounds.xMax, cameraBounds.yMax));
    }

    private void Start()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, -10f);
    }
}

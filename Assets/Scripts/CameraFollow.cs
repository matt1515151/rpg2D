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
    }

    private void Start()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, -10f);
    }
}

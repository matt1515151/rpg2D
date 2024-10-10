using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PointToCursor : MonoBehaviour
{
    public Vector2 mousePos;
    public Vector2 rotateTarget;
    public Shoot shoot;
    public Transform shootPoint;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (shoot.isGrappling)
        {
            ToHookPoint();
        }
        else
        {
            ToCursor();
        }

        transform.Find("Gun").GetComponent<SpriteRenderer>().flipY = rotateTarget.x < 0;
    }

    void ToCursor()
    {
        rotateTarget = mousePos;

        float targetAngle = Mathf.Atan2(rotateTarget.y, rotateTarget.x) * Mathf.Rad2Deg - 90f;

        float rotateAmount = targetAngle - transform.rotation.eulerAngles.z;

        transform.Rotate(0f, 0f, rotateAmount);
    }

    void ToHookPoint()
    {
        rotateTarget = new Vector3(shoot.GetGrapplePoint().x, shoot.GetGrapplePoint().y) - transform.position;

        float targetAngle = Mathf.Atan2(rotateTarget.y, rotateTarget.x) * Mathf.Rad2Deg - 90f;

        float rotateAmount = targetAngle - transform.rotation.eulerAngles.z;

        transform.Rotate(0f, 0f, rotateAmount);
    }
}
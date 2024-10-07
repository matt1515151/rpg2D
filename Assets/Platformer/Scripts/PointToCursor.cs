using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PointToCursor : MonoBehaviour
{
    public Vector2 mousePos;
    public Shoot shoot;

    void Update()
    {
        if (shoot.isGrappling)
        {
            ToHookPoint();
        }
        else
        {
            ToCursor();
        }
    }

    void ToCursor()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float targetAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;

        float rotateAmount = targetAngle - transform.rotation.eulerAngles.z;

        transform.Rotate(0f, 0f, rotateAmount);
    }

    void ToHookPoint()
    {
        Vector2 targetPos = new Vector3(shoot.GetGrapplePoint().x, shoot.GetGrapplePoint().y) - transform.position;

        float targetAngle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg - 90f;

        float rotateAmount = targetAngle - transform.rotation.eulerAngles.z;

        transform.Rotate(0f, 0f, rotateAmount);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    enum Grapple
    {
        NotGrappling,
        FirstClick,
        SecondClick
    }

    Grapple state = Grapple.NotGrappling;

    LineRenderer lineRenderer;
    Vector2 grapplePoint;
    SpringJoint2D joint;

    public PointToCursor pointToCursor;
    public LayerMask grappleableSurface;
    public Transform shootPoint, player;

    public float maxDist = 10f, minDist = 1f;
    public float dampingRatio;
    public float frequency;
    public float pullSpeed = 2f;

    public bool isGrappling;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && state == Grapple.NotGrappling)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0) && state == Grapple.FirstClick)
        {
            state = Grapple.SecondClick;
        }
        else if (Input.GetMouseButton(0) && state == Grapple.SecondClick)
        {
            Retract();
        }
        else if (Input.GetMouseButtonUp(0) && state == Grapple.SecondClick)
        {
            StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(player.position, pointToCursor.mousePos, maxDist, grappleableSurface))
        {
            isGrappling = true;
            state = Grapple.FirstClick;

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            joint.autoConfigureDistance = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector2.Distance(player.position, grapplePoint);
            joint.distance = distanceFromPoint;

            joint.dampingRatio = dampingRatio;
            joint.frequency = frequency;

            lineRenderer.positionCount = 2;
        }
    }

    void Retract()
    {
        if (joint.distance > minDist)
        {
            joint.distance -= pullSpeed * Time.deltaTime;
        }
    }

    void DrawRope()
    {
        if (!joint) return;

        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        isGrappling = false;
        state = Grapple.NotGrappling;
        player.GetComponent<PlayerMovement>().wasGrappling = true;

        lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    public Vector2 GetGrapplePoint()
    {
        return grapplePoint;
    }
}

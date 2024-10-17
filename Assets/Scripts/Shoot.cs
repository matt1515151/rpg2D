using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{

    LineRenderer lineRenderer;
    Vector2 grapplePoint;
    SpringJoint2D joint;
    Transform hitEnemy;

    public PointToCursor pointToCursor;
    public LayerMask grappleableSurface;
    public Transform shootPoint, player;

    public float maxDist = 10f, minDist = 1f;
    public float pullSpeed = 2f;
    // random variables to change how the swing feels
    public float dampingRatio;
    public float frequency;

    public bool isGrappling;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
        if (Input.GetMouseButton(1) && isGrappling)
        {
            Retract();
        }
        if (hitEnemy)
        {
            UpdateGrapplePoint();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(player.position, pointToCursor.rotateTarget, maxDist, grappleableSurface)) // rotateTarget will always be the mouse position in this case
        {
            if (hit.collider.CompareTag("non grappleable"))
            {
                isGrappling = false;
                return;
            }

            if (hit.collider.TryGetComponent<EnemyWalk>(out EnemyWalk enemy))
            {
                // if its a grappleable enemy, grapple to it
                if (enemy.grappleable)
                {
                    hitEnemy = hit.collider.transform;
                }
            }
            else
            {
                hitEnemy = null;
            }

            isGrappling = true;

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
        // if the SpringJoint2D doesn't exist (not grappling), then don't bother drawing the rope
        if (!joint) return;

        lineRenderer.SetPosition(0, shootPoint.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        isGrappling = false;
        player.GetComponent<PlayerMovement>().wasGrappling = true;

        lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    void UpdateGrapplePoint()
    {
        if (!joint) return;

        grapplePoint = hitEnemy.position;
        joint.connectedAnchor = grapplePoint;
    }

    public Vector2 GetGrapplePoint()
    {
        return grapplePoint;
    }
}

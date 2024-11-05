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
    PlayerInfo playerInfo;

    public PointToCursor pointToCursor;
    public LayerMask grappleableSurface;
    public Transform shootPoint, player;

    public float maxDist = 10f, minDist = 1f;
    public float pullSpeed = 2f;
    // random variables to change how the swing feels
    public float dampingRatio;
    public float frequency;

    public bool isGrappling;

    Transform indicatedEnemy;
    SpriteRenderer indicatorSR;

    public Sprite[] indicators = new Sprite[3];
    public GameObject indicator;

    void Awake()
    {
        playerInfo = FindAnyObjectByType<PlayerInfo>();
        lineRenderer = GetComponent<LineRenderer>();
        indicatorSR = Instantiate(indicator).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerInfo.hasHook)
        {
            GrappleIndicator();

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
            if (hit.collider.CompareTag("NonGrapple"))
            {
                isGrappling = false;
                return;
            }

            if (hit.collider.CompareTag("GrappleableEnemy"))
            {
                hitEnemy = hit.collider.transform;
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

    public void ShowHook()
    {
        transform.Find("Gun").GetComponent<SpriteRenderer>().enabled = true;
    }

    void GrappleIndicator()
    {
        if (isGrappling)
        {
            indicatorSR.sprite = null;
            return;
        }
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(player.position, pointToCursor.rotateTarget, maxDist, grappleableSurface)) // rotateTarget will always be the mouse position in this case
        {
            if (hit.collider.CompareTag("GrappleableEnemy"))
            {
                indicatedEnemy = hit.collider.transform;

                indicatorSR.sprite = indicators[2];
                indicatorSR.transform.position = indicatedEnemy.transform.position;
                return;
            }
            else
            {
                indicatedEnemy = null;
            }

            // if it doesn't hit an enemy
            if (hit.collider.CompareTag("NonGrapple"))
            {
                indicatorSR.sprite = indicators[1];
            }
            else
            {
                indicatorSR.sprite = indicators[0];
            }
            indicatorSR.transform.position = hit.point;
        }
        else
        {
            indicatorSR.sprite = null;
        }
    }
}

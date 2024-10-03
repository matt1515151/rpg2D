using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{
    public GameObject hookshot;
    public PointToCursor pointToCursor;
    public Rigidbody2D playerRB;
    [Space]
    public float shootForce;
    public bool isShotActive;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShotActive)
        {
            isShotActive = true;
            hookshot.SetActive(true);
            hookshot.transform.position = transform.position;
            hookshot.GetComponent<Rigidbody2D>().velocity = pointToCursor.mousePos * shootForce;
        }
    }
}

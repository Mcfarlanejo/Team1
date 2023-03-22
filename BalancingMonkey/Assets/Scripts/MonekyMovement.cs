using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonekyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            FreezeMonkey();
        }
        
    }

    private void FreezeMonkey()
    {
        rb.simulated = false;
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position- Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
    }

    private void OnMouseDrag()
    {
        if (rb.simulated)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
        }
    }
}

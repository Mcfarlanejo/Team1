using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonkeyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject attachedLimb;

    public bool connected = false;
    public bool dragging = false;
    public bool frozen = false;

    private Vector3 mousePosition;
    private float zOffSet = 0.1f;

    public bool touchingBanana = false;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void FreezeMonkey()
    {
        if (connected) 
        {
            HingeJoint2D newJoint = gameObject.AddComponent<HingeJoint2D>();
            newJoint.connectedBody = attachedLimb.GetComponent<Rigidbody2D>();  
        }
        frozen = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        mousePosition = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zOffSet));
    }

    private void OnMouseDrag()
    {
        dragging = true;
        if (!frozen)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zOffSet));
            rb.MovePosition (newPosition + mousePosition);
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.name == "Floor") || ((collision.collider.tag == "MonkeyPart") &&
            (collision.collider.GetComponentInParent<MonkeyController>().name != gameObject.GetComponentInParent<MonkeyController>().name)
             && (collision.collider.GetComponent<MonkeyMovement>().frozen == true)))
        {
            connected = true;
            attachedLimb = collision.collider.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {  
        if ((collision.tag == "Banana") && (frozen))
        {
            touchingBanana = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.collider.name == "Floor") || ((collision.collider.tag == "MonkeyPart") && 
            (collision.collider.GetComponentInParent<MonkeyController>().name != gameObject.GetComponentInParent<MonkeyController>().name)))
        {
            connected = false;
        }
    }
}

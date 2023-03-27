using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonkeyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 screenPoint;
    private Vector3 offset;

    public float power = 150;

    public bool connected = false;
    public bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void FreezeMonkey()
    {
        //rb.simulated = false;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position- Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
    }

    private void OnMouseDrag()
    {
        dragging = true;
        if (rb.simulated)
        {
            rb.AddForce(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))*power);
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.name == "Floor") || ((collision.collider.tag == "MonkeyPart") &&
            (collision.collider.GetComponentInParent<MonkeyController>().name != gameObject.GetComponentInParent<MonkeyController>().name)))
        {
            connected = true;
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

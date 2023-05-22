using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{

    //private GameObject monkey;

    void Start(){
        //monkey = gameObject;
    }

    void Update()
    {        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (Input.GetMouseButtonDown(0) && hit.collider && hit.collider.CompareTag("MonkeyPart"))
        {
            GameObject monkey = hit.collider.transform.parent.gameObject;
            monkey.layer = 6;
            foreach (MonkeyMovement child in monkey.GetComponent<MonkeyController>().monkeyLimbs)
            {
                 child.gameObject.layer = 6;
            }
            
            hit.collider.gameObject.GetComponent<MonkeyMovement>().dragging = true;
            // The Ray hit something!
            Debug.Log("hit something");
        }
    }
}

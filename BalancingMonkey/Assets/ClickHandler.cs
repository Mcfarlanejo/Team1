using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public Queue queue;
    void OnMouseDown()
    {
        // This code will run when the GameObject is clicked on
        Debug.Log("Prefab clicked!");
        queue.NewQueue();

    }
}

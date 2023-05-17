using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    

    void OnMouseDown()
    {
        GameObject myGameObject = GameObject.Find("MonkeyManager");
        Queue scriptA = myGameObject.GetComponent<Queue>();

        if (scriptA == null) {
        Debug.LogError("Queue component not found on MonkeyManager game object");
        }
        Debug.Log("Fire");

        // This code will run when the GameObject is clicked on
        Debug.Log("Prefab clicked!");
        scriptA.NewTurn();

    }
}

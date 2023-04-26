using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monkeyPrefab;
    public Vector3 spawnPosition;
    private int monkeyCounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            GameObject newMonkey = Instantiate(monkeyPrefab, spawnPosition, Quaternion.identity);
            int Overlay = LayerMask.NameToLayer("Overlay");
            newMonkey.layer = Overlay;
            newMonkey.name = "Monkey " + monkeyCounter;
            monkeyCounter++;
        }
    }
}

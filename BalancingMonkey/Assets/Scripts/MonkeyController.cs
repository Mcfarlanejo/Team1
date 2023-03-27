using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    [SerializeField] private MonkeyMovement[] monkeyLimbs;
    private bool monkeyTouchingFloor = false;
    // Start is called before the first frame update
    void Start()
    {
        monkeyLimbs = GetComponentsInChildren<MonkeyMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            foreach (MonkeyMovement monkeyPart in monkeyLimbs)
            {
                if (monkeyPart.touchingFloor)
                {
                    monkeyTouchingFloor = true;
                }
            }
        }
        if (monkeyTouchingFloor)
        {
            FreezeAllMonkeyParts();
        }
    }

    private void FreezeAllMonkeyParts()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            monkeyPart.FreezeMonkey();
        }
    }
}

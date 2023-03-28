using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour
{
    [SerializeField] private MonkeyMovement[] monkeyLimbs;
    // Start is called before the first frame update
    void Start()
    {
        monkeyLimbs = GetComponentsInChildren<MonkeyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("space")) && (BeingDragged()) && (Touching()))
        {
            FreezeAllMonkeyParts();

        }

        if (TouchingBanana())
        {
            Debug.Log("You Win!");
        }
    }

    private bool TouchingBanana()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            if (monkeyPart.touchingBanana)
            {
                return true;
            }
        }
        return false;
    }

    private bool Touching()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            if (monkeyPart.connected)
            {
                return true;
            }
        }
        return false;
    }

    private bool BeingDragged()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            if (monkeyPart.dragging)
            {
                return true;
            }
        }
        return false;
    }

    private void FreezeAllMonkeyParts()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            monkeyPart.FreezeMonkey();
        }
    }
}

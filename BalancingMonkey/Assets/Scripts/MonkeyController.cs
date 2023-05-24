using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyController : MonoBehaviour
{
    public MonkeyMovement[] monkeyLimbs;
    public GameObject youWinPannel;
    public GameObject nextTurnButton;
    // Start is called before the first frame update
    void Start()
    {
        monkeyLimbs = GetComponentsInChildren<MonkeyMovement>();
        youWinPannel = GameObject.Find("Winner");
        nextTurnButton = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("space")) && (BeingDragged()) && (Touching()) && (!Frozen()))
        {
            FreezeAllMonkeyParts();
            nextTurnButton.GetComponent<Button>().interactable = true;
        }

        if ((TouchingBanana()) && (!youWinPannel.transform.GetChild(0).gameObject.activeInHierarchy))
        {
            youWinPannel.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("You Win!");
        }
    }

    private bool Frozen()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            if (monkeyPart.frozen)
            {
                return true;
            }
        }
        return false;
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

    public void FreezeAllMonkeyParts()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            monkeyPart.FreezeMonkey();
        }
    }

    public void UnFreezeAllMonkeyParts()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            monkeyPart.UnFreezeMonkey();
        }
    }

    private bool SolidPosition()
    {
        foreach (MonkeyMovement monkeyPart in monkeyLimbs)
        {
            Rigidbody2D rb = monkeyPart.GetComponent<Rigidbody2D>();
            if ((rb.velocity.x > .05f) || (rb.velocity.y > .05f))
            {
                return false;
            }
        }
        return true;
    }
}

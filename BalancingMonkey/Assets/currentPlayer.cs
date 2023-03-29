using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentPlayer : MonoBehaviour
{
    private buttonAction btnScript;
    public string currPlayer;
    // Start is called before the first frame update
    void Start()
    {
        currPlayer = "p1";
    }

    public void EndTurn(){
        if (currPlayer == "p1"){
            currPlayer = "p2";
        }
        else {
            currPlayer = "p1";
        }
        Debug.Log(currPlayer);
    }
}

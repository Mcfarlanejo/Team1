using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAction : MonoBehaviour
{
    public Text currPlayer;
    private string[] players = { "Player 1", "Player 2" };
    private int currI = 0;

    void Start(){
        currPlayer.text = "Current Player: " + players[currI];
    }
    public void onButtonPress(){
        currI = (currI + 1) % players.Length;
        currPlayer.text = "Current Player: " + players[currI];
    }
}

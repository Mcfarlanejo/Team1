using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonAction : MonoBehaviour
{
    public Text currPlayer;
    private string[] players = { "Player 1", "Player 2" };
    private int currI = 0;
    private string p1, p2;

    void Start(){
        p1 = "Current Player: " + $"<color=#ff0000>Player 1</color>";
        p2 = "Current Player: " + $"<color=#0000ff>Player 2</color>";
        currPlayer.text = p1;
    }
    public void onButtonPress(){
        currI = (currI + 1) % players.Length;
        switch(currI){
            case 0:
                currPlayer.text = p1;
                break;
            case 1:
                currPlayer.text = p2;
                break;
        }
        
        GameObject myGameObject = GameObject.Find("MonkeyManager");
        Queue scriptA = myGameObject.GetComponent<Queue>();
        scriptA.NewTurn();
        
    }
}

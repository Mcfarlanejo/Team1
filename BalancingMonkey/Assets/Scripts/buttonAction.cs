using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonAction : MonoBehaviour
{
    private string[] players = { "Player 1", "Player 2" };
    private int currI = 0;
    public GameObject currentPlayerImage;
    public GameObject secondPlayer;

    void Start(){

    }
    public void onButtonPress(){
        currI = (currI + 1) % players.Length;
        switch(currI){
            case 0:
                currentPlayerImage.active = true;
                secondPlayer.active = false;
                break;
            case 1:
                currentPlayerImage.active = false;
                secondPlayer.active = true;
                break;
        }
        
        GameObject myGameObject = GameObject.Find("MonkeyManager");
        Queue scriptA = myGameObject.GetComponent<Queue>();
        scriptA.NewTurn();
        
    }
}

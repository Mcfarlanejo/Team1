using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Queue : MonoBehaviour
{
    public List<GameObject> monkeyObjects;
    public Texture[] queue;
    public SpriteRenderer spriteRenderer;
    public GameObject currentMonkey;
    public GameObject nextMonkey;
    public GameObject nextInQueue;
    public Button nextTurnButton;

    public Vector2 player1Position = new Vector2();
    public Vector2 player2Position = new Vector2();

    private int currI = 0;
    public int monkeyOne = 0;
    public int monkeyTwo = 0;
    public int iterations = 0;
    private int monkeyCounter = 0;

    public bool monkeyInPlayer1Spawn = false;
    public bool monkeyInPlayer2Spawn = false;



    // Start is called before the first frame update
    void Start()
    {   
        //SpawnNextInQueue();
        NewTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Updates everything when the currentMonkey has been placed
    public void NewTurn()
    {
        currI = (currI + 1);

        //first two monkeys are complete random.
        if(iterations < 2)
        {
            GameObject newMonkey = Instantiate(monkeyObjects[Random.Range(0,2)]);
            monkeyCounter++;
            newMonkey.name = "Monkey " + monkeyCounter;

            if (currI % 2 == 1)
            {
                GameObject player1Image = GameObject.Find("Player1Image");
                Image image = player1Image.GetComponent<Image>();
                newMonkey.transform.position = player1Position;
                ChangeImage(image, 1);
            } 
            else 
            {
                newMonkey.transform.position = player2Position;
                GameObject player2Image = GameObject.Find("Player2Image");
                Image image = player2Image.GetComponent<Image>();
                ChangeImage(image, 2);
            }
            iterations++;
        }
        else 
        {
            if(currI % 2 == 1)
            {
                GameObject newMonkey = Instantiate(monkeyObjects[monkeyOne]);
                monkeyCounter++;
                newMonkey.name = "Monkey " + monkeyCounter;
                GameObject player1Image = GameObject.Find("Player1Image");
                Image image = player1Image.GetComponent<Image>();
                newMonkey.transform.position = player1Position;
                ChangeImage(image, 1);
            } 
            else 
            {
                GameObject newMonkey = Instantiate(monkeyObjects[monkeyTwo]);
                monkeyCounter++;
                newMonkey.name = "Monkey " + monkeyCounter;
                newMonkey.transform.position = player2Position;
                GameObject player2Image = GameObject.Find("Player2Image");
                Image image = player2Image.GetComponent<Image>();
                ChangeImage(image, 2);
            }
        }

        nextTurnButton.interactable = false;
    }

    //public void SpawnNextInQueue()
    //{
    //    if (currI % 2 == 1)
    //    {
    //        GameObject newMonkey = Instantiate(monkeyObjects[monkeyOne]);
    //        monkeyCounter++;
    //        newMonkey.name = "Monkey " + monkeyCounter;
    //        newMonkey.transform.position = player1Position;
    //        monkeyInPlayer1Spawn = true;
    //        newMonkey.GetComponent<MonkeyController>().FreezeAllMonkeyParts();
    //    }
    //    else
    //    {
    //        GameObject newMonkey = Instantiate(monkeyObjects[monkeyTwo]);
    //        monkeyCounter++;
    //        newMonkey.name = "Monkey " + monkeyCounter;
    //        newMonkey.transform.position = player2Position;
    //        monkeyInPlayer2Spawn = true;
    //        newMonkey.GetComponent<MonkeyController>().FreezeAllMonkeyParts();
    //    }
    //}

    public void ChangeImage(Image image, int currentMonkey)
    {
        int nextMonkeyImage = Random.Range(0,queue.Length);
        Texture2D texture = (Texture2D)queue[nextMonkeyImage];
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Sprite sprite = Sprite.Create(texture, rect, Vector2.zero);
        image.sprite = sprite;

        //setting the value of the monkey in queue so when the new object is created the following turn 
        //its the correct monkey.
        if (currentMonkey == 1)
        {
            monkeyOne = nextMonkeyImage;
            Debug.Log("Monkey 1 is - " + nextMonkeyImage);
        }else 
        {
            monkeyTwo = nextMonkeyImage;
            Debug.Log("Monkey 2 is - " + nextMonkeyImage);
        }
    }
}

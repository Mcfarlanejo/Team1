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

    public Vector2 player1Position = new Vector2(-7.5f,-1.5f);
    public Vector2 player2Position = new Vector2(7.5f,-1f);

    

    // Start is called before the first frame update
    void Start()
    {

        GameObject newMonkey = Instantiate(monkeyObjects[Random.Range(0,2)]);
        newMonkey.transform.position = player1Position;

        
        
        GameObject nextInQueue = Instantiate(monkeyObjects[Random.Range(0,2)]);
        nextInQueue.transform.position = player2Position;

        GameObject player1Image = GameObject.Find("Player1Image");
        Image image = player1Image.GetComponent<Image>();
        Texture2D texture = (Texture2D)queue[Random.Range(0, 2)];
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Sprite sprite = Sprite.Create(texture, rect, Vector2.zero);
        image.sprite = sprite;

        GameObject player2Image = GameObject.Find("Player2Image");
        image = player2Image.GetComponent<Image>();
        texture = (Texture2D)queue[Random.Range(0, 2)];
        rect = new Rect(0, 0, texture.width, texture.height);
        sprite = Sprite.Create(texture, rect, Vector2.zero);
        image.sprite = sprite;



    }

    // Update is called once per frame
    void Update()
    {

    }

    // Updates everything when the currentMonkey has been placed
    public void NewTurn()
    {
        
        Debug.Log("This works somehow");
        

       // newMonkey = myList[Random.Range(0,2)];

    }
}

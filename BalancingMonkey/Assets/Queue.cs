using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public List<GameObject> myList;
    public List<GameObject> queue;
    public SpriteRenderer spriteRenderer;
    public GameObject currentMonkey;
    public GameObject nextMonkey;
    public GameObject nextInQueue;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject newMonkey = Instantiate(myList[1]);
        newMonkey.transform.position = new Vector2(-7.5f,-1.2f);
        GameObject nextInQueue = Instantiate(queue[Random.Range(0,2)]);
        nextInQueue.transform.position = new Vector2();
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updates everything when the currentMonkey has been placed
    public void NewTurn()
    {
        

        

       // newMonkey = myList[Random.Range(0,2)];

    }
}

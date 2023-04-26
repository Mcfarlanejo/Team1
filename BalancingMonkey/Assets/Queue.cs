using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> myList;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    public GameObject currentMonkey;
    public GameObject nextMonkey;
    public GameObject nextInQueue;

    // Start is called before the first frame update
    void Start()
    {
        GameObject currentMonkey = Instantiate(prefab);
        spriteRenderer = currentMonkey.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[Random.Range(0,2)];

        spriteRenderer = nextInQueue.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[Random.Range(0, 2)];

        currentMonkey.transform.position = new Vector3(-8.09f,-3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updates everything when the currentMonkey has been placed
    public void NewQueue()
    {
        Debug.Log("Hello");
    }
}

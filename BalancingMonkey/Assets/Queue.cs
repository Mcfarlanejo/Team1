using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> myList;
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject firstMonkey = Instantiate(prefab);
        spriteRenderer = prefab.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[];
        firstMonkey.transform.position = new Vector3(-8.09f,-3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking.Types;

public class GameManager : NetworkBehaviour
{
    public GameObject monkeyPrefab;
    public GameObject hostMonkey;
    public GameObject player2;
    public Vector3 spawnPosition;
    private int monkeyCounter = 1;
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void OnNetworkSpawn()
    {
        if (!IsHost)
        {
            monkeyPrefab = player2;
            spawnPosition = -spawnPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown("tab"))
        {
            SpawnMonkey();
        }
    }

    public void SpawnMonkey()
    {
        GameObject newMonkey = null;

        newMonkey = Instantiate(monkeyPrefab, spawnPosition, Quaternion.identity);
        newMonkey.name = "Monkey " + monkeyCounter;
            
        monkeyCounter++;
  
        if (newMonkey != null)
        {
            newMonkey.GetComponent<NetworkObject>().Spawn(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public GameObject monkeyPrefab;
    public Vector3 spawnPosition;
    private int monkeyCounter = 1;
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            SpawnMonkey();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            SpawnMonkey();
        }
    }

    public void SpawnMonkey()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("Host");
            GameObject newMonkey = Instantiate(monkeyPrefab, spawnPosition, Quaternion.identity);
            newMonkey.name = "Monkey " + monkeyCounter;
            monkeyCounter++;
        }
        else
        {
            SubmitRequestServerRPC();
        }
        
    }
    [ServerRpc]
    private void SubmitRequestServerRPC()
    {
        Debug.Log("Client");
        GameObject newMonkey = Instantiate(monkeyPrefab, spawnPosition, Quaternion.identity);
        newMonkey.name = "Monkey " + monkeyCounter;
        monkeyCounter++;
    }
}

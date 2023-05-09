using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

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
        if (IsHost)
        {
            monkeyPrefab = hostMonkey;
        }
        else
        {
            monkeyPrefab = player2;
            spawnPosition = -spawnPosition;
        }
    }

    public override void OnNetworkSpawn()
    {
        SpawnMonkey();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;
        if (Input.GetKeyDown("tab"))
        {
            SpawnMonkey();
        }
    }

    public void SpawnMonkey()
    {
        GameObject newMonkey = null;
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("Host");
            newMonkey = Instantiate(monkeyPrefab, spawnPosition, Quaternion.identity);
            newMonkey.name = "Monkey " + monkeyCounter;
            
            monkeyCounter++;
        }
        else
        {
            SubmitRequestServerRPC();
        }
        if (newMonkey != null)
        {
            newMonkey.GetComponent<NetworkObject>().Spawn(true);
        }
    }
    [ServerRpc]
    private void SubmitRequestServerRPC()
    {
        Debug.Log("Client");
        GameObject newMonkey = Instantiate(player2, spawnPosition, Quaternion.identity);
        newMonkey.name = "Monkey " + monkeyCounter;
        newMonkey.GetComponent<NetworkObject>().Spawn(true);
        monkeyCounter++;
    }
}

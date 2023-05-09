using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton; 
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        serverButton.onClick.AddListener(ServerButtonClick);
        hostButton.onClick.AddListener(HostButtonClick);
        clientButton.onClick.AddListener(ClientButtonClick);
    }

    private void ClientButtonClick()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void HostButtonClick()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void ServerButtonClick()
    {
        NetworkManager.Singleton.StartServer();
    }
}

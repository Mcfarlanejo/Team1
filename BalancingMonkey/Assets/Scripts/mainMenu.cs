using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void StartGame() {
        // Load the game scene
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu-Scene");
    }
    public void ExitGame() {
        // Exit the game
        Debug.Log("Quit");
        Application.Quit();
    }
}

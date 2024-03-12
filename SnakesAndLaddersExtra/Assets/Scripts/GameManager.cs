using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

//Reference: [insert youtube link]
public class GameManager : MonoBehaviour
{
    //Loads the game when the application is opened 
    public void RestartGame()
    {
        // Loads the first scene 
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    //Quits the game when the Quit Game button is pressed
    public void QuitGame()
    {
        #if UNITY_EDITOR
        // If the application is currently not playing
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        // Close the application
            Application.Quit();
        // Else continue playing
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

//Reference: [insert youtube link]

public class GameManager : MonoBehaviour

{
    //Boolean that checks whether the dice is able to be pressed or not
    public bool hasGameFinished, canClick;

    // Creates an instance of GameManager. Instance is a "copy" of something
    public static GameManager instance;

    //Loads the game when the application is opened 
    public void RestartGame()
    {
        // Loads the first scene when the game is restarted.
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

    // Initalises the dice when the game starts
    private void Awake()
    {
        // If the game manager is equal to nothing
        if (instance == null)
        {
            // Then initalise it
            instance = this;
        }
        else
        {
            // Else remove it. If the game is over, then we don't need it to be initialsed. 
            Destroy(gameObject);
        }
        
        // Allows the dice to be clicked when the game is running.
        canClick = true;
        // This is only true when the game is not finished.
        hasGameFinished = false;
    }
}

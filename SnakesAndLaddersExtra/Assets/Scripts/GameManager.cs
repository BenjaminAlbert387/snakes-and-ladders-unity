using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
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
            // Else remove it. If the game is over, then we don't need it to be initialsed
            Destroy(gameObject);
        }
        
        // Allows the dice to be clicked when the game is running
        canClick = true;
        // This is only true when the game is not finished
        hasGameFinished = false;
    }

    private void Update()
    {
        // If the game has finished, then the dice won't do anything. (Won't animate or return values)
        if (hasGameFinished || !canClick ) return;

        // If the right mouse click is used while the game is running, the code below will run.
        if (Input.GetMouseButtonDown(0))
        {
            // Reads the postion of the mouse relative to the game display
            UnityEngine.Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Creates a new vector based on the 2D postion of the mouse
            UnityEngine.Vector2 mousePosition2D = new UnityEngine.Vector2(mousePosition.x, mousePosition.y);

            // Detects whether the mouse is directly on the dice or not, comparing it to coordinates 0,0
            RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, UnityEngine.Vector2.zero);

            // If the mouse IS NOT on the dice when right clicked, then nothing happens
            if (!hit.collider) return;

            // If the mouse IS on the dice when right clicked, then it will animate and return values
            if (hit.collider.CompareTag("Dice"))
            {

            }
        }
    }
}

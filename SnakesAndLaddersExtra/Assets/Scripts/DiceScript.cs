using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    // Initialise an integer, as we will be using its value for player movement on the game board//
    int DiceRollValue;

    // SerializeField is used so Unity can view and edit non public assets//
    [SerializeField]

    // List the six dice sprites 
    List<Sprite> die;

    // Create a function that simulates the dice "rolling" in 2D.
    public void DiceRollImage()
    {
        // Use Unity's SpriteRender built in function to go through each dice face
    }
}

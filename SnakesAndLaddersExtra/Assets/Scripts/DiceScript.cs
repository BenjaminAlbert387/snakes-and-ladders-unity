using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

//Reference: 
public class DiceScript : MonoBehaviour
{
    // Initialise an integer, as we will be using its value for player movement on the game board
    int DiceRollValue;

    // SerializeField is used, so Unity can view and edit non public assets
    [SerializeField]

    // List the six dice sprites. 
    List<Sprite> die;

    // Create a function that simulates the dice "rolling" in 2D
    public void DiceRollImage()
    {
        // Use Unity's SpriteRender built in function to go through each dice face
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        // The dice selectes a dice face randomly, between 1 to 6
        renderer.sprite = die[Random.Range(0, die.Count)];
    }
    
    public void DiceRollSetImage()
    {
        // Sets up the dice face selected that will be outputted to the player
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        // As the dice only goes up to 6, take away one
        renderer.sprite = die[DiceRollValue - 1];
    }

    public void DiceRoll(int TemporaryValue)
    {
        // DiceRollValue becomes equal to the temporary value
        DiceRollValue = TemporaryValue;

        // Plays the dice roll animation created in Unity
        Animator animator = GetComponent<Animator>();
        animator.Play("Roll dice", -1, 0f);
    }
}

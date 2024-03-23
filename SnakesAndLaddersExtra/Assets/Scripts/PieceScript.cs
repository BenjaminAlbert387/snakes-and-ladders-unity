using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // SerializeField is used, so Unity can view and edit non public assets
    
    [SerializeField]

    // List the colours used for the player counters
    List<Color> colors;

    // Create a function that sets the colour of the player counters
    public void SetPlayerColors(Player player)
    {
        // Uses Unity's built in function to get the counter sprite
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        // The colour for each player is determined by player number
        renderer.color = colors[(int)player];
    }
}

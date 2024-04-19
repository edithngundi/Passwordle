using UnityEngine;

// The Row class represents a row of tiles in the game board
public class Row : MonoBehaviour
{
    // Array of tiles in the row
    public Tile[] tiles { get; private set; }
    // The word formed by the characters in the tiles of the row
    public string Word
    {
        get
        {
            string word = "";
            // Concatenate the characters from each tile to form the word
            for (int i = 0; i < tiles.Length; i++) {
                word += tiles[i].character;
            }

            return word;
        }
    }

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the Tile components in the children of this row
        tiles = GetComponentsInChildren<Tile>();
    }
}
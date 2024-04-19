using TMPro;
using UnityEngine;
using UnityEngine.UI;

// The Tile class represents a tile in the game board
public class Tile : MonoBehaviour
{
    // The State class represents the visual state of a tile
    [System.Serializable]
    public class State
    {
        // The fill color of the tile
        public Color fillColor;
        // The outline color of the tile
        public Color outlineColor;
    }

    // The current state of the tile
    public State state { get; private set; }
    // The character displayed on the tile
    public char character { get; private set; }

    // The Image component of the tile
    private Image fill;
    // The Outline component of the tile
    private Outline outline;
    // The TextMeshProUGUI component of the tile
    private TextMeshProUGUI text;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Get the Image, Outline, and TextMeshProUGUI components
        fill = GetComponent<Image>();
        outline = GetComponent<Outline>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Sets the character displayed on the tile
    public void SetLetter(char character)
    {
        this.character = character;
        text.text = character.ToString();
    }

    // Sets the visual state of the tile
    public void SetState(State state)
    {
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;
    }
}
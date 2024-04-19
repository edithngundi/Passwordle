using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Define the Board class that will manage the game board.
public class Board : MonoBehaviour
{
    // Mapping of characters to their respective indices
    private Dictionary<char, int> charToIndex;
    // Array of rows in the game board
    private Row[] rows;
    // Index of the current row
    private int rowIndex;
    // Index of the current column
    private int columnIndex;
    // This is the target password to be guessed
    private string word = "wAt#4!uO";

    // Tile states for different conditions
    [Header("Tiles")]
    public Tile.State emptyState;
    public Tile.State occupiedState;
    public Tile.State correctState;
    public Tile.State wrongCaseState;
    public Tile.State closeState;
    public Tile.State incorrectState;

    // UI elements for the game board
    [Header("UI")]
    public GameObject tryAgainButton;
    public GameObject oopsText;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        InitializeCharacterMapping();
        rows = GetComponentsInChildren<Row>();
    }

    // Initializes the character to index mapping
    private void InitializeCharacterMapping()
    {
        charToIndex = new Dictionary<char, int>();
        int index = 1;
        // Map digits, uppercase and lowercase letters to their respective indices
        for (char c = '0'; c <= '9'; c++, index++) charToIndex[c] = index;
        for (char c = 'A'; c <= 'Z'; c++, index++) charToIndex[c] = index;
        for (char c = 'a'; c <= 'z'; c++, index++) charToIndex[c] = index;
        // Mapping for special characters
        string specialChars = "`~!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";
        foreach (char c in specialChars) charToIndex[c] = index++;
    }

    // Update is called once per frame
    private void Update()
    {
        // Do not process inputs if the game board is disabled
        if (!enabled) return;
        // Process each character in the input string
        foreach (char c in Input.inputString)
        {
            if (charToIndex.ContainsKey(c))
            {
                Row currentRow = rows[rowIndex];
                if (columnIndex < currentRow.tiles.Length)
                {
                    currentRow.tiles[columnIndex].SetLetter(c);
                    currentRow.tiles[columnIndex].SetState(occupiedState);
                    columnIndex++;
                }
                else
                {
                    Debug.LogWarning("Row is full, cannot add more characters");
                }
            }
            else
            {
                Debug.LogWarning("Unsupported character or key pressed: " + c);
            }
        }
        // Submit the row if the Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return) && rowIndex < rows.Length)
        {
            SubmitRow(rows[rowIndex]);
            rowIndex++;
            // Reset columnIndex for the next row
            columnIndex = 0;
            if (rowIndex >= rows.Length)
            {
                // Disable the board, ending the game
                enabled = false; 
                oopsText.SetActive(false);
            }      
        }
    }

    // Submit the row and compare the guess with the target password
    private void SubmitRow(Row row)
    {
        string guess = row.Word;
        for (int i = 0; i < row.tiles.Length && i < word.Length; i++)
        {
            char g = guess[i];
            char correct = word[i];
            if (g == correct)
            {
                row.tiles[i].SetState(correctState);
            }
            else
            {
                int gIndex = charToIndex[g];
                int correctIndex = charToIndex[correct];
                int distance = Mathf.Abs(gIndex - correctIndex);

                if (char.ToLower(g) == char.ToLower(correct))
                    row.tiles[i].SetState(wrongCaseState);
                else if (distance <= 10)
                    row.tiles[i].SetState(closeState);
                else
                    row.tiles[i].SetState(incorrectState);
            }
        }
        oopsText.SetActive(guess != word);
    }

    // Clear the game board
    private void ClearBoard()
    {
        foreach (var row in rows)
        {
            foreach (var tile in row.tiles)
            {
                tile.SetLetter('\0');
                tile.SetState(emptyState);
            }
        }
        rowIndex = 0;
    }

    // Resets the game board for another try
    public void TryAgain()
    {
        ClearBoard();

        enabled = true;
    }

    // Called when the board becomes enabled and active
    private void OnEnable()
    {
        tryAgainButton.SetActive(false);
    }

    // Called when the board becomes disabled
    private void OnDisable()
    {
        tryAgainButton.SetActive(true);
    }
}
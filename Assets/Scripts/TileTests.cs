using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileTests : MonoBehaviour
{
    private Tile tile;
    private GameObject gameObject;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject();
        gameObject.AddComponent<Image>();
        gameObject.AddComponent<Outline>();
        gameObject.AddComponent<TextMeshProUGUI>();
        tile = gameObject.AddComponent<Tile>();
    }

    [Test]
    public void TestSetLetterUpdatesCharacterAndText()
    {
        char testChar = 'A';
        tile.SetLetter(testChar);
        Assert.AreEqual(testChar, tile.character);
        Assert.AreEqual(testChar.ToString(), tile.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    [Test]
    public void TestSetStateUpdatesVisuals()
    {
        Tile.State testState = new Tile.State
        {
            fillColor = Color.red,
            outlineColor = Color.blue
        };
        tile.SetState(testState);
        Assert.AreEqual(testState, tile.state);
        Assert.AreEqual(Color.red, tile.GetComponent<Image>().color);
        Assert.AreEqual(Color.blue, tile.GetComponent<Outline>().effectColor);
    }

    [Test]
    public void TestAwakeInitializesComponents()
    {
        tile.Awake();
        Assert.IsNotNull(tile.GetComponent<Image>());
        Assert.IsNotNull(tile.GetComponent<Outline>());
        Assert.IsNotNull(tile.GetComponentInChildren<TextMeshProUGUI>());
    }
}
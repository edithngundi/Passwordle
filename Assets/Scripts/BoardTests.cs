using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BoardTests
{
    private Board board;
    private GameObject boardGameObject;

    [SetUp]
    public void Setup()
    {
        boardGameObject = new GameObject();
        board = boardGameObject.AddComponent<Board>();
    }

    [Test]
    public void TestInitializeCharacterMappingCorrectness()
    {
        board.InitializeCharacterMapping();
        var charToIndex = typeof(Board).GetField("charToIndex", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(board) as Dictionary<char, int>;

        Assert.IsNotNull(charToIndex);
        Assert.AreEqual(1, charToIndex['0']);
        Assert.AreEqual(10, charToIndex['9']);
        Assert.AreEqual(11, charToIndex['A']);
        Assert.AreEqual(36, charToIndex['Z']);
        Assert.AreEqual(37, charToIndex['a']);
        Assert.AreEqual(62, charToIndex['z']);
        Assert.AreEqual(63, charToIndex['`']);
        Assert.AreEqual(92, charToIndex['?']);
    }

    [Test]
    public void TestUpdateMethodHandlingInput()
    {
        board.InitializeCharacterMapping();
        board.Awake();
        Input.inputString = "A";
        board.Update();

        Row currentRow = board.rows[0];
        Assert.AreEqual('A', currentRow.tiles[0].letter);
        Assert.AreEqual(Tile.State.Occupied, currentRow.tiles[0].state);
    }

    [Test]
    public void TestSubmitRowAccuracy()
    {
        board.InitializeCharacterMapping();
        board.Awake();
        Row testRow = new Row();
        testRow.Word = "wAt#4!uO";
        board.SubmitRow(testRow);

        Assert.AreEqual(Tile.State.Correct, testRow.tiles[0].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[1].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[2].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[3].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[4].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[5].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[6].state);
        Assert.AreEqual(Tile.State.Correct, testRow.tiles[7].state);
    }

    [TearDown]
    public void Teardown()
    {
        UnityEngine.Object.DestroyImmediate(boardGameObject);
    }
}
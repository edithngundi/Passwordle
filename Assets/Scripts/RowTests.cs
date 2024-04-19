using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[TestFixture]
public class RowTests
{
    private GameObject rowGameObject;
    private Row rowComponent;

    [SetUp]
    public void SetUp()
    {
        // Create a new GameObject and add the Row component to it
        rowGameObject = new GameObject();
        rowComponent = rowGameObject.AddComponent<Row>();
    }

    [Test]
    public void TestAwakeInitializesTilesCorrectly()
    {
        // Create child GameObjects and add Tile components
        GameObject child1 = new GameObject();
        child1.AddComponent<Tile>().character = 'A';
        child1.transform.parent = rowGameObject.transform;

        GameObject child2 = new GameObject();
        child2.AddComponent<Tile>().character = 'B';
        child2.transform.parent = rowGameObject.transform;

        // Call Awake manually to simulate the behavior
        rowComponent.Awake();

        // Check if tiles are correctly initialized
        Assert.IsNotNull(rowComponent.tiles);
        Assert.AreEqual(2, rowComponent.tiles.Length);
        Assert.AreEqual('A', rowComponent.tiles[0].character);
        Assert.AreEqual('B', rowComponent.tiles[1].character);
    }

    [Test]
    public void TestWordPropertyConcatenatesCharacters()
    {
        // Create child GameObjects and add Tile components
        GameObject child1 = new GameObject();
        child1.AddComponent<Tile>().character = 'H';
        child1.transform.parent = rowGameObject.transform;

        GameObject child2 = new GameObject();
        child2.AddComponent<Tile>().character = 'i';
        child2.transform.parent = rowGameObject.transform;

        // Call Awake manually to simulate the behavior
        rowComponent.Awake();

        // Check if Word property concatenates characters correctly
        Assert.AreEqual("Hi", rowComponent.Word);
    }

    [Test]
    public void TestWordPropertyWithEmptyTilesArray()
    {
        // Call Awake manually to simulate the behavior
        rowComponent.Awake();

        // Check if Word property handles empty tiles array
        Assert.AreEqual("", rowComponent.Word);
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup the GameObjects created for the test
        Object.DestroyImmediate(rowGameObject);
    }
}
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    // items lists (by group)
    public List<Item> groupAItems;
    public List<Item> groupBItems;
    public List<Item> groupCItems;
    public List<Item> groupDItems;
    public List<Item> groupEItems;

    void Awake()
    {
        // make sure there is only one instance of the ItemManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (!AreItemGroupsValid())
        {
            GameManager.instance.itemsComposition = false;
            Debug.LogWarning("Some Items are in the wrong group in the lists in the ItemManager! Check other errors to know which it is.");
        }

        // shuffle the lists
        groupAItems = RandomizeList(groupAItems);
        groupBItems = RandomizeList(groupBItems);
        groupCItems = RandomizeList(groupCItems);
        groupDItems = RandomizeList(groupDItems);
        groupEItems = RandomizeList(groupEItems);
    }

    public List<Item> GetItemsByGroup(string group)
    {
        switch (group)
        {
            case "A":
                return groupAItems;
            case "B":
                return groupBItems;
            case "C":
                return groupCItems;
            case "D":
                return groupDItems;
            case "E":
                return groupEItems;
            default:
                Debug.LogError("Group not found: " + group);
                return new List<Item>(); // return an empty list
        }
    }

    private List<Item> RandomizeList(List<Item> inputList)
    {
        List<Item> randomList = new List<Item>();
        System.Random random = new System.Random();

        while (inputList.Count > 0)
        {
            int randomIndex = random.Next(0, inputList.Count);
            randomList.Add(inputList[randomIndex]);
            inputList.RemoveAt(randomIndex);
        }

        return randomList;
    }

    public bool AreItemGroupsValid()
    {
        // check if all items are in the good group
        foreach (Item item in groupAItems)
        {
            if (item.group != "A")
            {
                Debug.LogWarning($"L'item {item.itemName} n'appartient pas au groupe A !");
                return false;
            }
        }

        foreach (Item item in groupBItems)
        {
            if (item.group != "B")
            {
                Debug.LogWarning($"L'item {item.itemName} n'appartient pas au groupe B !");
                return false;
            }
        }

        foreach (Item item in groupCItems)
        {
            if (item.group != "C")
            {
                Debug.LogWarning($"L'item {item.itemName} n'appartient pas au groupe C !");
                return false;
            }
        }

        foreach (Item item in groupDItems)
        {
            if (item.group != "D")
            {
                Debug.LogWarning($"L'item {item.itemName} n'appartient pas au groupe D !");
                return false;
            }
        }

        foreach (Item item in groupEItems)
        {
            if (item.group != "E")
            {
                Debug.LogWarning($"L'item {item.itemName} n'appartient pas au groupe E !");
                return false;
            }
        }

        return true;
    }
}

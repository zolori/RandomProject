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

        // shuffle the lists
        groupAItems = RandomizeList(groupAItems);
        groupBItems = RandomizeList(groupBItems);
        groupCItems = RandomizeList(groupCItems);
        groupDItems = RandomizeList(groupDItems);
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
}

using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    // items lists (by group)
    public List<Item> groupAItems;
    public List<Item> groupBItems;

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

        // randomize the lists
        groupAItems = RandomizeList(groupAItems);
        groupBItems = RandomizeList(groupBItems);
    }

    public List<Item> GetItemsByGroup(string group)
    {
        switch (group)
        {
            case "A":
                return groupAItems;
            case "B":
                return groupBItems;
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

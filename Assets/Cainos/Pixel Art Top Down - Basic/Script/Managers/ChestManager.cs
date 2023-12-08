using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public static ChestManager instance;

    private List<Chest> allChests = new List<Chest>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // get all chests - randomize the order
        Chest[] chestsArray = FindObjectsOfType<Chest>().OrderBy(x => UnityEngine.Random.value).ToArray();
        allChests.AddRange(chestsArray);
    }

    public List<Chest> GetChestsByGroup(string group)
    {
        List<Chest> chestsInGroup = new List<Chest>();

        foreach (Chest chest in allChests)
        {
            if (chest.group == group)
            {
                chestsInGroup.Add(chest);
            }
        }

        return chestsInGroup;
    }

    private IEnumerable<string> GetDistinctGroups()
    {
        HashSet<string> groups = new HashSet<string>();
        foreach (Chest chest in allChests)
        {
            groups.Add(chest.group);
        }
        return groups;
    }

    public void DistributeItems()
    {
        foreach (string group in GetDistinctGroups())
        {
            List<Item> itemsForGroup = ItemManager.instance.GetItemsByGroup(group);
            List<Chest> chestsInGroup = GetChestsByGroup(group);

            DistributeItemsEquitably(chestsInGroup, itemsForGroup);
        }
    }

    // give items to chest, equitably (+-1)
    private void DistributeItemsEquitably(List<Chest> chests, List<Item> items)
    {
        int itemsPerChest = items.Count / chests.Count;
        int remainingItems = items.Count % chests.Count;

        int itemIndex = 0;

        foreach (Chest chest in chests)
        {
            int itemsToGive = itemsPerChest + (remainingItems > 0 ? 1 : 0);

            List<Item> itemsToGiveList = items.GetRange(itemIndex, itemsToGive);
            chest.AddItemToChestRange(itemsToGiveList);

            itemIndex += itemsToGive;
            remainingItems--;
        }
    }
}

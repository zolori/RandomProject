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

    public List<Chest> GetAllChest()
    {
        return allChests;
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


    private bool IsItemInCorrectGroup(Item item, string expectedGroup)
    {
        // Check if the item's group matches the expected group
        return item.group == expectedGroup;
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

    public bool IsChestCompositionSolvable()
    {
        int nbError = 0;

        foreach (string group in GetDistinctGroups())
        {
            List<Item> itemsForGroup = ItemManager.instance.GetItemsByGroup(group);
            List<Chest> chestsInGroup = GetChestsByGroup(group);

            // 0 chest but items to give
            if (chestsInGroup.Count < 1 && itemsForGroup.Count > 0)
            {
                Debug.LogWarning($"Le groupe {group} n'est pas solvable. Nombre d'objets : {itemsForGroup.Count}, Nombre de coffres : {chestsInGroup.Count}");
                nbError = +1;
            }

            // less items than chest
            if (itemsForGroup.Count < chestsInGroup.Count)
            {
                Debug.LogWarning($"Le groupe {group} n'est pas solvable. Nombre d'objets : {itemsForGroup.Count}, Nombre de coffres : {chestsInGroup.Count}");
                nbError = +1;
            }

            // empty chest?
            foreach (Chest chest in chestsInGroup)
            {
                if (chest.GetItemsCount() == 0)
                {
                    Debug.LogWarning($"Le coffre {chest.name} dans le groupe {group} est vide.");
                    nbError = +1;
                }
            }

            // item in wrong group?
            foreach (Item item in itemsForGroup)
            {
                if (!IsItemInCorrectGroup(item, group))
                {
                    Debug.LogWarning($"L'objet {item.itemName} n'est pas dans le groupe {group} approprié.");
                    nbError = +1;
                }
            }
        }

        // to get all the messages no matter what
        if (nbError > 0)
        {
            return true;
        }
        else
        {
            return true;
        }
    }
}

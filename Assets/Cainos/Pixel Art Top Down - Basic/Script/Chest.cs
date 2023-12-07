using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public string group;
    private List<Item> itemList;
    private List<Item> itemsInChest;

    private void Start()
    {
        itemList = new List<Item>(ItemManager.instance.GetItemsByGroup(group));
        itemsInChest = new List<Item>();

        int maxItemsPerChest = Mathf.CeilToInt(itemList.Count / (float)GameManager.instance.GetNumberOfChestsByGroup(group));

        while (itemsInChest.Count < maxItemsPerChest && itemList.Count > 0)
        {
            Item chosenItem = ChooseRandomItem();
            itemsInChest.Add(chosenItem);
            itemList.Remove(chosenItem);
        }

        Debug.Log($"Items in chest ({gameObject.name}): {string.Join(", ", itemsInChest.ConvertAll(i => i.itemName))}");
    }

    private Item ChooseRandomItem()
    {
        return itemList[Random.Range(0, itemList.Count)];
    }

    public void OpenChest()
    {
        foreach (Item item in itemsInChest)
        {
            GiveItemToPlayer(item);
        }

        Destroy(gameObject);
    }

    private void GiveItemToPlayer(Item item)
    {
        // add to main ui the image of the item
        AddToMainUI(item);

        // popup
        ActivateItemObtainedPopup(item);

        // grant the associated ability to the player
        PlayerManager.instance.GrantAbility(item.grantedAbility);
    }

    private void ActivateItemObtainedPopup(Item obtainedItem)
    {
        UIManager.instance.ShowItemObtainedPopup(obtainedItem.itemName, obtainedItem.itemDescription, obtainedItem.itemIcon);
    }

    private void AddToMainUI(Item item)
    {
        UIManager.instance.AddImageToScrollView(item.itemIcon);
    }
}

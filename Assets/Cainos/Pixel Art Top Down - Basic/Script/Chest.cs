using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public string group;

    [SerializeField]
    private List<Item> itemsInChest;

    private int numberOfItemsGiven;

    public void AddItemToChestRange(List<Item> items)
    {
        itemsInChest.AddRange(items);
    }

    public void OpenChest()
    {
        numberOfItemsGiven = 1;
        foreach (Item item in itemsInChest)
        {
            GiveItemToPlayer(item);
            numberOfItemsGiven += 1;
        }

        Destroy(gameObject);
    }

    private void GiveItemToPlayer(Item item)
    {
        // add to main ui the image of the item
        AddToMainUI(item);

        // popup
        ActivateItemObtainedPopup(item, numberOfItemsGiven, itemsInChest.Count);
    }

    private void ActivateItemObtainedPopup(Item obtainedItem, int currentNumber, int totalItems)
    {
        UIManager.instance.ShowItemObtainedPopup(obtainedItem.itemName, obtainedItem.itemDescription, obtainedItem.itemIcon, currentNumber, totalItems);
    }

    private void AddToMainUI(Item item)
    {
        UIManager.instance.AddImageToScrollView(item.itemIcon);
    }
}

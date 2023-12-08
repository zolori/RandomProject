using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public string group;

    [SerializeField]
    private List<Item> itemsInChest;

    public void AddItemToChestRange(List<Item> items)
    {
        itemsInChest.AddRange(items);
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

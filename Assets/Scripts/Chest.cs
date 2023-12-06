using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public string group;
    private List<Item> itemList;

    void Start()
    {
        itemList = ItemManager.instance.GetItemsByGroup(group);

        Item chosenItem = ChooseRandomItem();

        Debug.Log("Item in chest: " + chosenItem.itemName);


        itemList.Remove(chosenItem);
        GiveItemToPlayer(chosenItem);
    }

    private Item ChooseRandomItem()
    {
        return itemList[Random.Range(0, itemList.Count)];
    }
    
    private void GiveItemToPlayer(Item item)
    {
        // add to main ui the image of the item
        UIManager.instance.AddImageToScrollView(item.itemIcon);

        // popup
        ActivateItemObtainedPopup(item);

        // grant the associated ability to the player
        PlayerManager.instance.GrantAbility(item.grantedAbility);
    }

    private void ActivateItemObtainedPopup(Item obtainedItem)
    {
        UIManager.instance.ShowItemObtainedPopup(obtainedItem.itemName, obtainedItem.itemDescription ,obtainedItem.itemIcon);
    }

    private void AddToMainUI()
    {

    }
}

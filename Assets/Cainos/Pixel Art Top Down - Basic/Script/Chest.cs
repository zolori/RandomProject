using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Chest : MonoBehaviour
{
    public string group;
    private List<Item> itemList;

    private Item chosenItem;

    void Start()
    {
        itemList = ItemManager.instance.GetItemsByGroup(group);

        chosenItem = ChooseRandomItem();

        Debug.Log("Item in chest: " + chosenItem.itemName);


        itemList.Remove(chosenItem);
    }

    private Item ChooseRandomItem()
    {
        return itemList[Random.Range(0, itemList.Count)];
    }
    
    public void OpenChest()
    {
        GiveItemToPlayer(chosenItem);
    }

    private void GiveItemToPlayer(Item item)
    {
        // add to main ui the image of the item
        AddToMainUI(item);

        // popup
        ActivateItemObtainedPopup(item);

        // grant the associated ability to the player
        PlayerManager.instance.GrantAbility(item.grantedAbility);


        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

    private void ActivateItemObtainedPopup(Item obtainedItem)
    {
        UIManager.instance.ShowItemObtainedPopup(obtainedItem.itemName, obtainedItem.itemDescription ,obtainedItem.itemIcon);
    }

    private void AddToMainUI(Item item)
    {
        UIManager.instance.AddImageToScrollView(item.itemIcon);
    }
}

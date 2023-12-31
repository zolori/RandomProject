using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public string group;
    public bool isDisplayedOnMinimap = false;

    [SerializeField]
    private List<Item> itemsInChest;

    private int numberOfItemsGiven;

    public SoundPlayer soundPlayer;
    public AudioClip openChest;

    // get unique id for the seed
    public int GetUniqueID()
    {
        return GetInstanceID();
    }

    public void AddItemToChestRange(List<Item> items)
    {
        itemsInChest.AddRange(items);
    }

    public int GetItemsCount()
    {
        return itemsInChest.Count;
    }

    public void OpenChest()
    {
        // play sound
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundEffect(openChest);
        }
        else
        {
            Debug.LogWarning("soundPlayer Empty");
        }

        numberOfItemsGiven = 1;
        foreach (Item item in itemsInChest)
        {
            GiveItemToPlayerUI(item);
            numberOfItemsGiven += 1;
        }

        // remove from list of chests
        ChestManager.instance.RemoveChestFromAllChestList(this);

        if (isDisplayedOnMinimap)
        {
            // display new chest on minimap
            MinimapManager.instance.UpdateMinimap();
        }

        Destroy(gameObject);
    }

    private void GiveItemToPlayerUI(Item item)
    {
        // add to main ui the image of the item
        AddToMainUI(item);

        // popup
        ActivateItemObtainedPopup(item, numberOfItemsGiven, itemsInChest.Count);

        //give ability to player
        PlayerManager.instance.GrantAbility(item.grantedAbility);
    }

    private void ActivateItemObtainedPopup(Item obtainedItem, int currentNumber, int totalItems)
    {
        UIManager.instance.ShowItemObtainedPopup(obtainedItem.itemName, obtainedItem.itemDescription, obtainedItem.itemIcon, currentNumber, totalItems);
    }

    private void AddToMainUI(Item item)
    {
        UIManager.instance.AddItemToScrollView(item.itemIcon, item.name);
    }
}

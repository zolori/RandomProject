using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public static MinimapManager instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateMinimap();
    }

    public void UpdateMinimap()
    {
        Chest chestToShow = getValidChest();
        if (chestToShow != null)
        {
            SpriteRenderer chestSpriteRenderer = chestToShow.transform.Find("SpriteMap").GetComponent<SpriteRenderer>();

            if (chestSpriteRenderer != null)
            {
                chestToShow.isDisplayedOnMinimap = true;
                chestSpriteRenderer.enabled = true;
            }
            Debug.Log("Chest Sprite Renderer null : problem for minimap.");
        }
    }

    private Chest getValidChest()
    {
        List<Chest> availableChestList;

        if (ChestManager.instance.GetChestsByGroup("A").Count > 0 && ChestManager.instance.GetChestsByGroup("A") != null)
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAA");
            availableChestList = ChestManager.instance.GetChestsByGroup("A");
        }

        else if (ChestManager.instance.GetChestsByGroup("B").Count > 0 && ChestManager.instance.GetChestsByGroup("B") != null)
        {
            Debug.Log("BBBBBBBBBBBBBBBBBBBB");
            availableChestList = ChestManager.instance.GetChestsByGroup("B");
        }

        else if (ChestManager.instance.GetChestsByGroup("C").Count > 0 && ChestManager.instance.GetChestsByGroup("C") != null)
        {
            availableChestList = ChestManager.instance.GetChestsByGroup("C");
        }

        else if (ChestManager.instance.GetChestsByGroup("D").Count > 0 && ChestManager.instance.GetChestsByGroup("D") != null)
        {
            availableChestList = ChestManager.instance.GetChestsByGroup("D");
        }

        else
        {
            Debug.Log("No chest existing anymore.");
            return null;
        }

        Chest chestRandom = GetRandomElement(availableChestList);
        Debug.Log(chestRandom);
        return chestRandom;
    }


    private static Chest GetRandomElement<Chest>(List<Chest> chestList)
    {
        if (chestList == null || chestList.Count == 0)
        {
            throw new ArgumentException("List is null or empty");
        }

        int randomIndex = new System.Random().Next(chestList.Count);
        return chestList[randomIndex];
    }

}

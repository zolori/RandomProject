using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Dictionary<string, int> chestCountByGroup = new Dictionary<string, int>();

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

        // get all chests
        Chest[] allChests = FindObjectsOfType<Chest>();
        CountChestsByGroup(allChests);
    }

    private void CountChestsByGroup(Chest[] chests)
    {
        foreach (Chest chest in chests)
        {
            if (!chestCountByGroup.ContainsKey(chest.group))
            {
                chestCountByGroup[chest.group] = 1;
            }
            else
            {
                chestCountByGroup[chest.group]++;
            }
        }
    }

    public int GetNumberOfChestsByGroup(string group)
    {
        return chestCountByGroup.ContainsKey(group) ? chestCountByGroup[group] : 0;
    }
}



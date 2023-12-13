using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public WorldGenerator worldGenerator;

    [Header("Check if game is solvable")]
    [SerializeField]
    private bool chestsComposition;
    public bool itemsComposition;

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
    }

    private void Start()
    {
        // start to distribute items in chests
        ChestManager.instance.DistributeItems();
        chestsComposition = CheckChests();

        worldGenerator.GenerateSeed();
    }

    private bool CheckChests()
    {
        // check the condition of the random in chest
        if (!ChestManager.instance.IsChestCompositionSolvable())
        {
            return false;
        }

        return true;
    }

}

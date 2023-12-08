using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private ChestManager chestManager;

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

        chestManager = FindObjectOfType<ChestManager>();
    }

    private void Start()
    {
        // start to distribute items in chests
        chestManager.DistributeItems();
    }
}

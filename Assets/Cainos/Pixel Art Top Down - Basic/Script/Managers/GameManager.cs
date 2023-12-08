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
        // Vous devez appeler la fonction de distribution du ChestManager
        chestManager.DistributeItems();
    }
}

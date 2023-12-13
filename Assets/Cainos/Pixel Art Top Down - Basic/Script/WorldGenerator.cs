using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public void GenerateSeed()
    {
        List<Chest> allChests = ChestManager.instance.GetAllChest();

        if (allChests != null)
        {
            SeedGenerator.GenerateSeed(allChests);
            int worldSeed = SeedGenerator.GetGeneratedSeed();

            // init generator of name with the seed
            Random.InitState(worldSeed);
        }
    }
}

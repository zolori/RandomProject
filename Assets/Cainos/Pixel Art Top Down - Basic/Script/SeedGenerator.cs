using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    private static int generatedSeed;
    private static int userEnteredSeed;

    public static void GenerateSeed(List<Chest> allChests)
    {
        int seed;

        if (userEnteredSeed != 0)
        {
            seed = userEnteredSeed; // if exist
        }
        else
        {
            // create new seed
            seed = 17;

            foreach (Chest chest in allChests)
            {
                seed = (seed * 23) + chest.GetUniqueID();
            }
        }

        generatedSeed = seed;
    }

    public static int GetGeneratedSeed()
    {
        return generatedSeed;
    }

    public static void SetUserEnteredSeed(int seed)
    {
        userEnteredSeed = seed;
    }
}

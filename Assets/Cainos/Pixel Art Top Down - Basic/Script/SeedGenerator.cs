using System.Collections.Generic;
using UnityEngine;

public class SeedGenerator : MonoBehaviour
{
    private static int generatedSeed;
    private static int userEnteredSeed; // Nouvelle variable

    public static void GenerateSeed(List<Chest> allChests)
    {
        int seed;

        if (userEnteredSeed != 0)
        {
            // Utilisez la seed entrée par l'utilisateur si elle existe
            seed = userEnteredSeed;
        }
        else
        {
            // Générez une nouvelle seed normalement
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

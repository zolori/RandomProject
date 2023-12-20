using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Dictionary<string, bool> playerAbilities = new Dictionary<string, bool>();

    public static PlayerManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePlayerAbilities();
    }

    void InitializePlayerAbilities()
    {
        playerAbilities.Add("fire", false);
        playerAbilities.Add("goThroughWalls", false);
        playerAbilities.Add("swim", false);
        playerAbilities.Add("doubleJump", false);
        playerAbilities.Add("climb", false);
        playerAbilities.Add("breakObstacles", false);
        playerAbilities.Add("key1", false);
        playerAbilities.Add("key2", false);
        playerAbilities.Add("parchment1", false);
        playerAbilities.Add("parchment2", false);
    }

    public void GrantAbility(string abilityName)
    {
        // grant new ability
        if (playerAbilities.ContainsKey(abilityName))        
            playerAbilities[abilityName] = true;        
        else        
            Debug.LogError("Ability not found: " + abilityName);        
    }

    public bool HasAbility(string abilityName)
    {
        // check if has ability
        if (playerAbilities.ContainsKey(abilityName))        
            return playerAbilities[abilityName];        
        else        
            Debug.LogError("Ability not found: " + abilityName);
            return false;        
    }
}

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
        playerAbilities.Add("goThroughHoles", false);
        playerAbilities.Add("swim", false);
        playerAbilities.Add("sprint", false);
        playerAbilities.Add("doubleJump", false);
        playerAbilities.Add("climb", false);
        playerAbilities.Add("breakObstacles", false);
        playerAbilities.Add("fly", false);
        playerAbilities.Add("castSpells", false);
        playerAbilities.Add("camouflage", false);
        playerAbilities.Add("nightVision", false);
    }

    public void GrantAbility(string abilityName)
    {
        // grant new ability
        if (playerAbilities.ContainsKey(abilityName))
        {
            playerAbilities[abilityName] = true;
        }
        else
        {
            Debug.LogError("Ability not found: " + abilityName);
        }
    }

    public bool HasAbility(string abilityName)
    {
        // check if has ability
        if (playerAbilities.ContainsKey(abilityName))
        {
            return playerAbilities[abilityName];
        }
        else
        {
            Debug.LogError("Ability not found: " + abilityName);
            return false;
        }
    }
}

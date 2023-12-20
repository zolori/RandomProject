using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAbility : MonoBehaviour
{
    public string AbilityNeeded;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AbilityHandler abilityHandler = other.gameObject.GetComponent<AbilityHandler>();
            Debug.Log("AbilityNeeded : " + AbilityNeeded + ", Other.name : " + other.gameObject.name + ", Has Ability? : " + PlayerManager.instance.HasAbility(AbilityNeeded));

            if (abilityHandler != null)
            {
                if (PlayerManager.instance.HasAbility(AbilityNeeded))
                {
                    print("Check successful! You can go");

                    switch (AbilityNeeded)
                    {
                        case "goThroughWalls":
                            abilityHandler.HandleGoThroughWalls();
                            break;
                        case "swim":
                            abilityHandler.HandleSwim();
                            break;
                        case "fire":
                            abilityHandler.HandleFire();
                            break;
                        case "doubleJump":
                            abilityHandler.HandleDoubleJump();
                            break;
                        case "climb":
                            abilityHandler.HandleClimb();
                            break;
                        case "breakObstacles":
                            abilityHandler.HandleBreakObstacles();
                            break;
                        case "completeKey":
                            abilityHandler.HandleCompleteKey();
                            break;
                        case "parchment1":
                            abilityHandler.HandleParchment1();
                            break;
                        case "parchment2":
                            abilityHandler.HandleParchment2();
                            break;
                        case "lastChest":
                            abilityHandler.HandleLastChest();
                            break;
                        default:
                            print("None of the abilities correspond");
                            break;
                    }
                }
            }
        }
    }
}



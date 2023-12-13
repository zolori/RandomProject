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
                        case "goThroughHoles":
                            Debug.Log("AAAAAAAAAAH");
                            abilityHandler.HandleGoThroughHoles();
                            break;
                        case "swim":
                            abilityHandler.HandleSwim();
                            break;
                        case "sprint":
                            abilityHandler.HandleSprint();
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
                        case "fly":
                            abilityHandler.HandleFly();
                            break;
                        case "castSpells":
                            abilityHandler.HandleCastSpells();
                            break;
                        case "camouflage":
                            abilityHandler.HandleCamouflage();
                            break;
                        case "nightVision":
                            abilityHandler.HandleNightVision();
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



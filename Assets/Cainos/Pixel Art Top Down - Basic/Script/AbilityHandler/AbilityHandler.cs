using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{

    public GameObject GoThroughHoles; // just a test


    public virtual void HandleGoThroughHoles()
    {
        print("Handling ability to go through holes.");
        Destroy(GoThroughHoles); // just a test
    }
    public virtual void HandleSwim()
    {
        print("Handling ability to swim.");
    }
    public virtual void HandleSprint()
    {
        print("Handling ability to sprint.");
    }
    public virtual void HandleDoubleJump()
    {
        print("Handling ability to double jump.");
    }
    public virtual void HandleClimb()
    {
        print("Handling ability to climb.");
    }
    public virtual void HandleBreakObstacles()
    {
        print("Handling ability to break obstacles.");
    }
    public virtual void HandleFly()
    {
        print("Handling ability to fly.");
    }
    public virtual void HandleCastSpells()
    {
        print("Handling ability to cast spells.");
    }
    public virtual void HandleCamouflage()
    {
        print("Handling ability to camouflage.");
    }
    public virtual void HandleNightVision()
    {
        print("Handling ability for night vision.");
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    public GameObject GoThroughWalls;
    public GameObject Swim;
    public GameObject Fire;
    public GameObject DoubleJump;
    public GameObject Climb;
    public GameObject BreakObstacles;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Parchment1;
    public GameObject Parchment2;


    public virtual void HandleGoThroughWalls()
    {
        Destroy(GoThroughWalls);
    }
    public virtual void HandleSwim()
    {
        Destroy(Swim);
    }
    public virtual void HandleFire()
    {
        Destroy(Fire);
    }
    public virtual void HandleDoubleJump()
    {
        Destroy(DoubleJump);
    }
    public virtual void HandleClimb()
    {
        Destroy(Climb);
    }
    public virtual void HandleBreakObstacles()
    {
        Destroy(BreakObstacles);
    }
    public virtual void HandleKey1()
    {
    }
    public virtual void HandleKey2()
    {
    }
    public virtual void HandleParchment1()
    {
    }
    public virtual void HandleParchment2()
    {
    }
}


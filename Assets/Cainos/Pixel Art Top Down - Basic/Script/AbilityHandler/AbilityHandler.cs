using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilityHandler : MonoBehaviour
{
    public GameObject GoThroughWalls;
    public GameObject Swim;
    public GameObject Fire;
    public GameObject DoubleJump;
    public GameObject Climb;
    public GameObject BreakObstacles;
    public GameObject CompleteKey;
    public GameObject DoorOpen;
    public GameObject Parchment1;
    public GameObject Parchment2;
    public GameObject LastChest;
    public GameObject Ending;


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
    public virtual void HandleCompleteKey()
    {
        Destroy(CompleteKey);
        DoorOpen.SetActive(true);
    }
    public virtual void HandleParchment1()
    {
        Parchment1.SetActive(true);
    }
    public virtual void HandleParchment2()
    {
        Parchment2.SetActive(true);
    }
    public virtual void HandleLastChest()
    {
        Destroy(LastChest);
    }


}


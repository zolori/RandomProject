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

    public SoundPlayer soundPlayer;
    public AudioClip useAbility;

    public virtual void HandleGoThroughWalls()
    {
        PlaySound();
        Destroy(GoThroughWalls);
    }
    public virtual void HandleSwim()
    {
        PlaySound();
        Destroy(Swim);
    }
    public virtual void HandleFire()
    {
        PlaySound();
        Destroy(Fire);
    }
    public virtual void HandleDoubleJump()
    {
        PlaySound();
        Destroy(DoubleJump);
    }
    public virtual void HandleClimb()
    {
        PlaySound();
        Destroy(Climb);
    }
    public virtual void HandleBreakObstacles()
    {
        PlaySound();
        Destroy(BreakObstacles);
    }
    public virtual void HandleCompleteKey()
    {
        PlaySound();
        Destroy(CompleteKey);
        DoorOpen.SetActive(true);
    }
    public virtual void HandleParchment1()
    {
        PlaySound();
        Parchment1.SetActive(true);
    }
    public virtual void HandleParchment2()
    {
        PlaySound();
        Parchment2.SetActive(true);
    }
    public virtual void HandleLastChest()
    {
        PlaySound();
        Destroy(LastChest);
    }

    private void PlaySound()
    {
        // play sound
        if (soundPlayer != null)
        {
            soundPlayer.PlaySoundEffect(useAbility);
        }
        else
        {
            Debug.LogWarning("soundPlayer Empty");
        }
    }


}


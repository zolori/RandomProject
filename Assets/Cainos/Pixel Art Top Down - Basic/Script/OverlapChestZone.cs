using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapChestZone : MonoBehaviour
{
    public Chest Chest;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if (other.CompareTag("Player"))
        {
            print("Enter Player");
            Chest.OpenChest();
        }
    }
}

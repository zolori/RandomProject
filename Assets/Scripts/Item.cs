using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public string category;
    public Sprite itemIcon;
    public string grantedAbility; // what the item allows you too
}

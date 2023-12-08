using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Scriptable/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public string group;
    public Sprite itemIcon;
    public string grantedAbility; // what the item allows you too
}

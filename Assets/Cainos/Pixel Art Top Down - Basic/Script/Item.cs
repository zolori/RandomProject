using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Scriptable/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;

    public string group; // the group it belongs to
    public string grantedAbility; // what the item allows you too

    // get unique id for the seed
    public int GetUniqueID()
    {
        return GetInstanceID();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class ItemInstance
{
    public string itemName;
    public string itemDescription;

    public Sprite itemIcon;

    public GameObject itemPrefab;

    public ObjectType itemType;

    public ItemInstance(ItemData item)
    {
        itemName = item.name;
        itemDescription = item.description;
        itemIcon = item.icon;
        itemType = item.type;
    }
}

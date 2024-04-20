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

    public Sort itemSort;

    public ItemData originalItem;

    public int itemAmount = 1;

    public ItemInstance(ItemData item)
    {
        itemName = item.name;
        itemDescription = item.description;
        itemIcon = item.icon;
        itemSort = item.sort;
        originalItem = item;
    }
}

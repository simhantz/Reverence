using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class ItemInstance
{
    public string name = null;

    public Sort sort;

    public string description = null;

    public Sprite icon = null;

    public GameObject prefab = null;

    public ItemData originalData = null;

    public int amountOf = 1;

    public ItemInstance(ItemData item)
    {
        name = item.name;
        description = item.baseDescription;
        icon = item.baseIcon;
        sort = item.baseSort;
        originalData = item;
    }
}

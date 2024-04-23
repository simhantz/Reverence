using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// En instance av ett item
/// </summary>
[Serializable]
public class ItemInstance
{
    public string name = null;

    public Sort sort;

    public string description = null;

    public Sprite icon = null;

    public GameObject prefab = null;

    public ItemData originalData = null;

    // Stack-sizen... ända skillnaden mellan nu... 
    // hoppas på fler annars är den här klassen typ helt onödig.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
/// <summary>
/// För att kategorisera typen av item
/// </summary>
public enum Sort { Consume, Weapon, Equipment, QuestItem, Material,  }

/// <summary>
/// Orginala datan för ett item
/// </summary>
[CreateAssetMenu(fileName = "new Item", menuName = "Items")]
public class ItemData : ScriptableObject
{
    public new string name;

    public Sort baseSort;

    public string baseDescription;

    public Sprite baseIcon = null;

    public GameObject basePrefab = null;

}

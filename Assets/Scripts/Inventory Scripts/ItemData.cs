using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum ObjectType { Consume, Weapon, Equipment, QuestItem, Material,  }

[CreateAssetMenu(fileName = "new Item", menuName = "Items")]
public class ItemData : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public GameObject prefab;

    public ObjectType type;
}

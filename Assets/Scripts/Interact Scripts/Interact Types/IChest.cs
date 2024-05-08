using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptet som hanterar kist interaktioner. Ärver från IInteract
/// </summary>

[RequireComponent(typeof(InventoryManager))]
public class IChest : MonoBehaviour, IInteract
{
    [SerializeField] private InventoryManager _chestInventory;

    private void Awake()
    {
        _chestInventory = gameObject.GetComponent<InventoryManager>();
    }
    public void Interact()
    {
        OpenChest();
    }

    // OpenChest() tar just nu allting istället för att öppna något WIP
    // Fixat
    private void OpenChest()
    {
        if (Global.ChestUI == null)
        {
            Debug.Log("ChestUI Reference is NOT exist");
            return;
        }
        Global.ChestUI.inventoryManager = _chestInventory;
        Global.ChestUI.OpenUI();
    }
}

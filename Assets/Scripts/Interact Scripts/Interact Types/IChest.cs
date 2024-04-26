using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptet som hanterar kist interaktioner. Ärver från IInteract
/// </summary>
public class IChest : MonoBehaviour, IInteract
{
    [SerializeField] private ChestUI uI;
    private InventoryManager _chestInventory;

    private void Awake()
    {
        // Finns det en "InventoryManager" sätter _chestInventory till den

        //if (TryGetComponent<InventoryManager>(out InventoryManager inv))
        //{
        //    _chestInventory = inv;
        //}
        //else Debug.Log("Failed to get InventoryManager Component");
    }
    public void Interact()
    {
        OpenChest();
    }

    // OpenChest() tar just nu allting istället för att öppna något WIP
    private void OpenChest()
    {
        uI.OpenUI();
        //BetterInteract.playerInventory.TakeAll(_chestInventory);
    }
}

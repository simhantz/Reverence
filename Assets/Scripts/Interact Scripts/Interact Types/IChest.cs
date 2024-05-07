using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scriptet som hanterar kist interaktioner. �rver fr�n IInteract
/// </summary>

public class IChest : MonoBehaviour, IInteract
{
    [SerializeField] private ChestUI _uI;
    private InventoryManager _chestInventory;

    private void Awake()
    {
    }
    public void Interact()
    {
        OpenChest();
    }

    // OpenChest() tar just nu allting ist�llet f�r att �ppna n�got WIP
    private void OpenChest()
    {
        if (_uI == null) { Debug.Log("ChestUI Refrence is NOT exist"); return; }
        _uI.OpenUI();
        //BetterInteract.playerInventory.TakeAll(_chestInventory);
    }
}

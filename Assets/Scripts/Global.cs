using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// S� jag kan ta vissa saker lite varifr�n som helst
/// </summary>
public class Global : MonoBehaviour
{
    public InventoryManager SetPlayerInv = null;
    public PlayerStatus SetPlayerStatus = null;
    public ChestUI SetChestUI = null;



    public static InventoryManager PlayerInventory;
    public static PlayerStatus PlayerStatus;
    public static ChestUI ChestUI;


    private void Awake()
    {
        PlayerInventory = SetPlayerInv;
        PlayerStatus = SetPlayerStatus;
        ChestUI = SetChestUI;
    }
}

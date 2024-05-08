using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Global : MonoBehaviour
{
    public InventoryManager SetPlayerInv = null;
    public ChestUI SetChestUI = null;



    public static InventoryManager PlayerInventory;
    public static ChestUI ChestUI;


    private void Awake()
    {
        PlayerInventory = SetPlayerInv;

        ChestUI = SetChestUI;
    }
}

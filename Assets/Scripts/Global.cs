using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Global : MonoBehaviour
{
    public InventoryManager SetPlayerInv = null;


    public static InventoryManager PlayerInventory;

    private void Awake()
    {
        PlayerInventory = SetPlayerInv;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : UI
{

    // Inventory canvas måste vara på annars funkar ej. Fixa det idiot

    [SerializeField] private InventoryManager inventory = null;

    [Header("Keybinds")]
    [SerializeField] private KeyCode inventoryButton = KeyCode.Tab;

    private GameObject panel;
    private SlotUI[] arraySlots;


    void Awake()
    {
        if (inventory != null)
        {
            inventoryManager = inventory;
        }

        SetPanel(this.gameObject);
        SetIconsArray(this.gameObject);

    }


    void Update()
    {
        if (inventory == null)
        {
            Debug.Log("No inventory refrence");
            return;
        }

        if (Input.GetKeyDown(inventoryButton))
        {
            OpenUI();
        }
        
    }
}

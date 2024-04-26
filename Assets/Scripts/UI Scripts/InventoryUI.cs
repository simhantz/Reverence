using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : UI
{
    [SerializeField] private InventoryManager inventory = null;

    [Header("Keybinds")]
    [SerializeField] private KeyCode inventoryButton = KeyCode.Tab;
    
    void Awake()
    {
        if (inventory != null)
        {
            inventoryManager = inventory;
        }
        panel = SetPanel(this.gameObject);
        iconArray = GetIconsArray(panel);
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
            OpenInventory();
        }
        
    }
}

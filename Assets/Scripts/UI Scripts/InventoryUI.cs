using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Hanterar spelarens inventory UI
/// </summary>
public class InventoryUI : UI
{

    // Inventory canvas måste vara på annars funkar ej. Fixa det idiot(jag)

    [SerializeField] private InventoryManager _inventory = null;

    [Header("Keybinds")]
    [SerializeField] private KeyCode _inventoryButton = KeyCode.Tab;

    private GameObject _panelUI;
    private SlotUI[] _arraySlots;


    void Awake()
    {
        if (_inventory != null)
        {
            inventoryManager = _inventory;
        }

        SetPanel(this.gameObject);
        SetSlotsArray(this.gameObject);

    }


    void Update()
    {
        if (_inventory == null)
        {
            Debug.Log("No inventory refrence");
            return;
        }

        if (Input.GetKeyDown(_inventoryButton))
        {
            OpenUI();
        }
        
    }
}

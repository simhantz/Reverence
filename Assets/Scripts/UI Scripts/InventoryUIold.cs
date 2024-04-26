using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Hanterar UI f�r ett inventory. Oftast spelarens
/// </summary>
public class InventoryUIold : MonoBehaviour
{
    [Header("Keybind")]
    [SerializeField] private KeyCode _inventoryButton = KeyCode.Tab;

    [Header("References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private InventoryManager _inventory;

    // Objectet som sitter under detta gameObject. S� man kan kontrollera det hela tiden
    private GameObject inventoryBackPanel;

    // En array f�r SlotUI. S� jag kan �ndra p� dess sprite
    private SlotUI[] icons;

    private void Awake()
    {
        // Tar de komponenterna/objecten jag vill ha
        inventoryBackPanel = gameObject.transform.GetChild(0).gameObject;
        icons = inventoryBackPanel.GetComponentsInChildren<SlotUI>();

        // L�gger in funktionen i min delegate. S� jag slipper skapa references f�r att kunna anv�nda funktionen
        _inventory.onInventoryUpdate += RefreshUI;
    }
    private void Start()
    {
        // En tempor�r l�sning d�r inventory interfacet startar p� och st�ngts av direkt p� start
        // Annars funkar inte skiten
        inventoryBackPanel.SetActive(false);
    }
    private void Update()
    {
        OpenInventory();
    }
    /// <summary>
    /// Refreshar interfacet
    /// </summary>
    private void RefreshUI()
    {
        // G�r igenom varje SlotUI i icons arrayen
        for (int i = 0; i < icons.Length; i++)
        {
            // S�tter ikonen p� SlotUI till den motsvarande i item-listan
            if (_inventory.listOfItems.Count > i)
            {
                icons[i].image.sprite = _inventory.listOfItems[i].icon;
                icons[i].image.enabled = true;
            }

            // Om SlotUI har en ikon men listan inte �r stor nog f�r att n� upp till den i-positionen
            // st�nger jag av komponenten och s�tter spriten/ikonen till null
            if (icons[i].image.sprite != null && _inventory.listOfItems.Count <= i)
            {
                icons[i].image.enabled = false;
                icons[i].image.sprite = null;
            }
        }
    }
    /// <summary>
    /// �ppnar inventory interfacet om man klickar p� r�tt knapp
    /// </summary>
    void OpenInventory()
    {
        if (Input.GetKeyDown(_inventoryButton))
        {
            // St�nger av PlayerController s� man inte kan r�ra p� sig
            _playerController.enabled = inventoryBackPanel.activeSelf;

            // S�tter interfacet till motsatsen av vad det �r nu. �r det st�ngt �ppnar det och vice versa
            inventoryBackPanel.SetActive(!inventoryBackPanel.activeSelf);

            // Stoppar all r�relse. Funkar kast som fan...
            _playerController.rb.velocity = Vector2.zero;
        }
    }
}

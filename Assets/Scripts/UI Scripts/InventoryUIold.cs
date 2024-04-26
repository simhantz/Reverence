using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Hanterar UI för ett inventory. Oftast spelarens
/// </summary>
public class InventoryUIold : MonoBehaviour
{
    [Header("Keybind")]
    [SerializeField] private KeyCode _inventoryButton = KeyCode.Tab;

    [Header("References")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private InventoryManager _inventory;

    // Objectet som sitter under detta gameObject. Så man kan kontrollera det hela tiden
    private GameObject inventoryBackPanel;

    // En array för SlotUI. Så jag kan ändra på dess sprite
    private SlotUI[] icons;

    private void Awake()
    {
        // Tar de komponenterna/objecten jag vill ha
        inventoryBackPanel = gameObject.transform.GetChild(0).gameObject;
        icons = inventoryBackPanel.GetComponentsInChildren<SlotUI>();

        // Lägger in funktionen i min delegate. Så jag slipper skapa references för att kunna använda funktionen
        _inventory.onInventoryUpdate += RefreshUI;
    }
    private void Start()
    {
        // En temporär lösning där inventory interfacet startar på och stängts av direkt på start
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
        // Går igenom varje SlotUI i icons arrayen
        for (int i = 0; i < icons.Length; i++)
        {
            // Sätter ikonen på SlotUI till den motsvarande i item-listan
            if (_inventory.listOfItems.Count > i)
            {
                icons[i].image.sprite = _inventory.listOfItems[i].icon;
                icons[i].image.enabled = true;
            }

            // Om SlotUI har en ikon men listan inte är stor nog för att nå upp till den i-positionen
            // stänger jag av komponenten och sätter spriten/ikonen till null
            if (icons[i].image.sprite != null && _inventory.listOfItems.Count <= i)
            {
                icons[i].image.enabled = false;
                icons[i].image.sprite = null;
            }
        }
    }
    /// <summary>
    /// Öppnar inventory interfacet om man klickar på rätt knapp
    /// </summary>
    void OpenInventory()
    {
        if (Input.GetKeyDown(_inventoryButton))
        {
            // Stänger av PlayerController så man inte kan röra på sig
            _playerController.enabled = inventoryBackPanel.activeSelf;

            // Sätter interfacet till motsatsen av vad det är nu. Är det stängt öppnar det och vice versa
            inventoryBackPanel.SetActive(!inventoryBackPanel.activeSelf);

            // Stoppar all rörelse. Funkar kast som fan...
            _playerController.rb.velocity = Vector2.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{

    // Inventory canvas måste vara på annars funkar ej. Fixa det idiot

    [Header("References")]
    [SerializeField] protected PlayerController _playerController;

    protected InventoryManager inventoryManager = null;

    // Objectet som sitter under detta gameObject. Så man kan kontrollera det hela tiden
    protected GameObject inventoryBackPanel = null;

    // En array för SlotUI. Så jag kan ändra på dess sprite
    protected SlotUI[] icons;

    private void Awake()
    {
    }
    private void Start()
    {
        if (inventoryManager != null && inventoryBackPanel != null)
        {
            // Lägger in funktionen i min delegate. Så jag slipper skapa references för att kunna använda funktionen
            inventoryManager.onInventoryUpdate += RefreshUI;
        }

        // En temporär lösning där inventory interfacet startar på och stängts av direkt på start
        // Annars funkar inte skiten
        inventoryBackPanel.SetActive(false);
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
            if (inventoryManager.listOfItems.Count > i)
            {
                icons[i].image.sprite = inventoryManager.listOfItems[i].icon;
                icons[i].image.enabled = true;
            }

            // Om SlotUI har en ikon men listan inte är stor nog för att nå upp till den i-positionen
            // stänger jag av komponenten och sätter spriten/ikonen till null
            if (icons[i].image.sprite != null && inventoryManager.listOfItems.Count <= i)
            {
                icons[i].image.enabled = false;
                icons[i].image.sprite = null;
            }
        }
    }
    /// <summary>
    /// Öppnar inventory interfacet om man klickar på rätt knapp
    /// </summary>
    public void OpenUI(GameObject extraComponent = null)
    {
        // Stänger av PlayerController så man inte kan röra på sig
        _playerController.enabled = inventoryBackPanel.activeSelf;

        // Sätter interfacet till motsatsen av vad det är nu. Är det stängt öppnar det och vice versa
        inventoryBackPanel.SetActive(!inventoryBackPanel.activeSelf);

        // Stoppar all rörelse. Funkar kast som fan...
        _playerController.rb.velocity = Vector2.zero;

        if (extraComponent != null)
        {

        }

    }
    /// <summary>
    /// Tar panelen som sakerna är grupperade i
    /// </summary>
    /// <param name="thisGameObject">Det här gameObjectet</param>
    /// <returns>Den panelen</returns>
    protected void SetPanel(GameObject thisGameObject)
    {
        inventoryBackPanel = gameObject.transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// Tar en array av SlotUI scripts från panel gruppen
    /// </summary>
    /// <param name="PanelUI">Panelen som den tar från</param>
    protected void SetIconsArray(GameObject thisGameObject)
    {
        //icons = thisGameObject.GetComponentsInChildren<SlotUI>();
        icons = gameObject.transform.GetChild(0).gameObject.GetComponentsInChildren<SlotUI>();

    }

}

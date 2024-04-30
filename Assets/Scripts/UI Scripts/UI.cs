using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{

    // Inventory canvas m�ste vara p� annars funkar ej. Fixa det idiot

    [Header("References")]
    [SerializeField] protected PlayerController _playerController;

    protected InventoryManager inventoryManager = null;

    // Objectet som sitter under detta gameObject. S� man kan kontrollera det hela tiden
    protected GameObject inventoryBackPanel = null;

    // En array f�r SlotUI. S� jag kan �ndra p� dess sprite
    protected SlotUI[] icons;

    private void Awake()
    {
    }
    private void Start()
    {
        if (inventoryManager != null && inventoryBackPanel != null)
        {
            // L�gger in funktionen i min delegate. S� jag slipper skapa references f�r att kunna anv�nda funktionen
            inventoryManager.onInventoryUpdate += RefreshUI;
        }

        // En tempor�r l�sning d�r inventory interfacet startar p� och st�ngts av direkt p� start
        // Annars funkar inte skiten
        inventoryBackPanel.SetActive(false);
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
            if (inventoryManager.listOfItems.Count > i)
            {
                icons[i].image.sprite = inventoryManager.listOfItems[i].icon;
                icons[i].image.enabled = true;
            }

            // Om SlotUI har en ikon men listan inte �r stor nog f�r att n� upp till den i-positionen
            // st�nger jag av komponenten och s�tter spriten/ikonen till null
            if (icons[i].image.sprite != null && inventoryManager.listOfItems.Count <= i)
            {
                icons[i].image.enabled = false;
                icons[i].image.sprite = null;
            }
        }
    }
    /// <summary>
    /// �ppnar inventory interfacet om man klickar p� r�tt knapp
    /// </summary>
    public void OpenUI(GameObject extraComponent = null)
    {
        // St�nger av PlayerController s� man inte kan r�ra p� sig
        _playerController.enabled = inventoryBackPanel.activeSelf;

        // S�tter interfacet till motsatsen av vad det �r nu. �r det st�ngt �ppnar det och vice versa
        inventoryBackPanel.SetActive(!inventoryBackPanel.activeSelf);

        // Stoppar all r�relse. Funkar kast som fan...
        _playerController.rb.velocity = Vector2.zero;

        if (extraComponent != null)
        {

        }

    }
    /// <summary>
    /// Tar panelen som sakerna �r grupperade i
    /// </summary>
    /// <param name="thisGameObject">Det h�r gameObjectet</param>
    /// <returns>Den panelen</returns>
    protected void SetPanel(GameObject thisGameObject)
    {
        inventoryBackPanel = gameObject.transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// Tar en array av SlotUI scripts fr�n panel gruppen
    /// </summary>
    /// <param name="PanelUI">Panelen som den tar fr�n</param>
    protected void SetIconsArray(GameObject thisGameObject)
    {
        //icons = thisGameObject.GetComponentsInChildren<SlotUI>();
        icons = gameObject.transform.GetChild(0).gameObject.GetComponentsInChildren<SlotUI>();

    }

}

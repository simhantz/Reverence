using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public KeyCode inventoryButton = KeyCode.Tab;

    public PlayerController playerController;
    public InventoryManager inventory;

    private GameObject inventoryBackPanel;

    private SlotUI[] icons;
    private void Awake()
    {
        inventoryBackPanel = gameObject.transform.GetChild(0).gameObject;
        icons = inventoryBackPanel.GetComponentsInChildren<SlotUI>();

        inventory.onInventoryUpdate += RefreshUI;
    }
    private void Start()
    {
        inventoryBackPanel.SetActive(false);
    }
    private void Update()
    {
        OpenInventory();
    }
    private void RefreshUI()
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (inventory.listOfItems.Count > i)
            {
                icons[i].image.sprite = inventory.listOfItems[i].icon;
                icons[i].image.enabled = true;
            }
            if (icons[i].image.sprite != null && inventory.listOfItems.Count <= i)
            {
                icons[i].image.enabled = false;
                icons[i].image.sprite = null;
            }
        }
    }
    void OpenInventory()
    {
        if (Input.GetKeyDown(inventoryButton))
        {
            playerController.enabled = inventoryBackPanel.activeSelf;
            inventoryBackPanel.SetActive(!inventoryBackPanel.activeSelf);
            playerController.rb.velocity = Vector2.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public KeyCode inventoryButton = KeyCode.Tab;

    public PlayerController playerController;

    private GameObject inventoryBackPanel;
    private void Awake()
    {
        inventoryBackPanel = gameObject.transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(inventoryButton))
        {
            playerController.enabled = inventoryBackPanel.activeSelf;
            inventoryBackPanel.SetActive(!inventoryBackPanel.activeSelf);
            playerController.rb.velocity = Vector2.zero;
        }
    }
}

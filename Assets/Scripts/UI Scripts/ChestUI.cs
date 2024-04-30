using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : UI
{
    [SerializeField] internal InventoryManager chest = null;

    private GameObject button;
    private Button[] buttonArray = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (chest != null)
        {
            inventoryManager = chest;
        }
        SetPanel(this.gameObject);
        SetIconsArray(this.gameObject);

        button = gameObject.transform.GetChild(1).gameObject;
        button.SetActive(false);

        buttonArray = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        button.SetActive(inventoryBackPanel.activeSelf);
    }
    public int GetIndexOfButton(Button button)
    {
        for (int i = 0; i < chest.listOfItems.Count; i++)
        {
            if (buttonArray[i] == button)
            {
                return i;
            }
        }
        return (-1); // Possible error
    }
}

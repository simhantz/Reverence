using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : UI
{
    [SerializeField] internal InventoryManager chest = null;

    private GameObject _button;
    private Button[] _buttonArray = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (chest != null)
        {
            inventoryManager = chest;
        }
        SetPanel(this.gameObject);
        SetIconsArray(this.gameObject);

        _button = gameObject.transform.GetChild(1).gameObject;
        _button.SetActive(false);

        _buttonArray = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        _button.SetActive(inventoryBackPanel.activeSelf);
    }
    public int GetIndexOfButton(Button button)
    {
        for (int i = 0; i < chest.listItems.Count; i++)
        {
            if (_buttonArray[i] == button)
            {
                return i;
            }
        }
        return (-1); // Possible error
    }
}

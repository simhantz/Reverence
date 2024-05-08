using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : UI
{
    private GameObject _buttonTakeAll;
    private Button[] _buttonArray = null;

    // Start is called before the first frame update
    void Awake()
    {
        SetPanel(this.gameObject);
        SetSlotsArray(this.gameObject);
        

        _buttonTakeAll = gameObject.transform.GetChild(1).gameObject;
        _buttonTakeAll.SetActive(false);

        _buttonArray = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        _buttonTakeAll.SetActive(inventoryBackPanel.activeSelf);
    }
    public int GetIndexOfButton(Button button)
    {
        for (int i = 0; i < inventoryManager.listItems.Count; i++)
        {
            if (_buttonArray[i] == button)
            {
                return i;
            }
        }
        return (-1); // Possible error
    }
}

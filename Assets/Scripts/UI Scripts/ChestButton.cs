using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestButton : MonoBehaviour
{
    private Button button;
    private ChestUI chestUI;
    void Awake()
    {
        chestUI = GetComponentInParent<ChestUI>();
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(Transfer);
    }
    void Update()
    {
        
    }
    private void Debugger()
    {
        Debug.Log("Klickade knappen");
    }
    private void Transfer()
    {
        int index = chestUI.GetIndexOfButton(button);
        if (index == -1)
        {
            Debug.Log("Klickade knappen har inget på den platsen");
            return;
        }
        BetterInteract.playerInventory.TransferFrom(chestUI.chest, index);
    }
}

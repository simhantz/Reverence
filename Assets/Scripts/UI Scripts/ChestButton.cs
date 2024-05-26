using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestButton : MonoBehaviour
{
    private Button _button;
    private ChestUI _chestUI;
    void Awake()
    {
        _chestUI = GetComponentInParent<ChestUI>();
        _button = gameObject.AddComponent<Button>();
        _button.onClick.AddListener(TransferToMainInventory);
    }
    /// <summary>
    /// En test grej
    /// </summary>
    private void Debugger()
    {
        Debug.Log("Klickade knappen");
    }
    /// <summary>
    /// Som den säger tar saker från den klickade knappen och för till spelarens inventory
    /// </summary>
    private void TransferToMainInventory()
    {
        // Kollar index positionen i inventoriet och om den har något
        int index = _chestUI.GetIndexOfButton(_button);
        if (index == -1)
        {
            Debug.Log("Klickade knappen har inget på den platsen");
            return;
        }
        Global.PlayerInventory.TransferFrom(_chestUI.inventoryManager, index);

        //BetterInteract.playerInventory.TransferFrom(_chestUI.chest, index);
    }
}

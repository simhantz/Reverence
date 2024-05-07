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
        _button.onClick.AddListener(Transfer);
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
        int index = _chestUI.GetIndexOfButton(_button);
        if (index == -1)
        {
            Debug.Log("Klickade knappen har inget på den platsen");
            return;
        }
        Global.PlayerInventory.TransferFrom(_chestUI.chest, index);

        //BetterInteract.playerInventory.TransferFrom(_chestUI.chest, index);
    }
}

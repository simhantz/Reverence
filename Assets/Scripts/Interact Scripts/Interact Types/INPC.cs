using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPC : MonoBehaviour, IInteract
{
    private InventoryManager _npcInventory = null;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (TryGetComponent<InventoryManager>(out InventoryManager inv))
        {
            _npcInventory = inv;
        }
    }
    public void Interact()
    {
        TalkToNPC();
        OnTalkGiveFirst();
    }
    private void TalkToNPC()
    {
        spriteRenderer.color = Color.blue;
    }
    private void OnTalkGiveFirst()
    {
        if (_npcInventory == null)
        {
            return;
        }
        BetterInteract.playerInventory.TransferFrom(_npcInventory);
        Debug.Log("BLA BLA BLA, TAKE THIS THING ");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPC : MonoBehaviour, IInteract
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    public void Interact()
    {
        TalkToNPC();
    }
    private void TalkToNPC()
    {
        spriteRenderer.color = Color.blue;
    }
}

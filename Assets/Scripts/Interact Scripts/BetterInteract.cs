using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BetterInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 1f;
    void Update()
    {
        
    }
    public virtual void Interact()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactRange);
        if (collider.TryGetComponent<InteractCatch>(out InteractCatch interactCatch))
        {

        }
    }
}

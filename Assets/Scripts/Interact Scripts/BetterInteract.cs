using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterInteract : MonoBehaviour
{
    [SerializeField] private float interactRange = 1f;
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactRange);
        //if (collider.TryGetComponent<>)
        //{

        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Teleporterar spelaren tillbaka till starten om den trillar av. �r antagligen f�r lite nu dock
/// </summary>
public class BackToStart : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.position = Vector3.zero;
    }
}

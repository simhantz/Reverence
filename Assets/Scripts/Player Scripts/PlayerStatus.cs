using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Status f�r spelaren.
/// </summary>
public class PlayerStatus : Status
{
    // Kan vara fler typer av attacker s� d�rf�r SlashDamage
    public static int SlashDamage;

    private void Start()
    {
        // s�tter PlayerStatus' SlashDamage till den fr�n basklassen
        SlashDamage = slashDamage;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Status för spelaren.
/// </summary>
public class PlayerStatus : Status
{
    // Kan vara fler typer av attacker så därför SlashDamage
    public static int SlashDamage;

    private void Start()
    {
        // sätter PlayerStatus' SlashDamage till den från basklassen
        SlashDamage = slashDamage;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : Status
{
    public static int SlashDamage;

    private void Start()
    {
        SlashDamage = slashDamage;
    }
}

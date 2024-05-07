using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int HP;
    public static int MaxHP;

    public static int SlashDamage;

    [Header("Stats")]
    public int healthPoints;
    public int maxHealthPoints;

    public int slashDamage;

    [Header("Status")]
    public bool alive = true;

    private void Start()
    {
        healthPoints = maxHealthPoints;
        SlashDamage = slashDamage;
        HP = healthPoints;
        MaxHP = maxHealthPoints;
    }
    private void Update()
    {
        if (healthPoints <= 0)
        {
            alive = false;
        }

        if (!alive)
        {
            Debug.Log("Player is dead");
        }

        if (HP != healthPoints || MaxHP != maxHealthPoints)
        {
            HP = healthPoints;
            MaxHP = maxHealthPoints;
        }
    }


}

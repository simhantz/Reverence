using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Basklass för Statusar för levande saker
/// </summary>
public class Status : MonoBehaviour
{
    [Header("Stats")]
    public int healthPoints = 100;
    public int maxHealthPoints = 100;

    public int slashDamage = 2;

    [Header("Status")]
    public bool alive = true;

    // Döds medellande
    private bool sentDeathMes = false;

    
    private void Update()
    {
        if (healthPoints <= 0)
        {
            alive = false;
        }

        // tar bort objectet som dog
        if (!sentDeathMes && !alive)
        {
            Debug.Log(gameObject.name + " died");
            sentDeathMes = true;
            gameObject.SetActive(false);
        }
    }

}

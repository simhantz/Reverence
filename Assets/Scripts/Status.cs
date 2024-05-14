using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("Stats")]
    public int healthPoints = 100;
    public int maxHealthPoints = 100;

    public int slashDamage = 2;

    [Header("Status")]
    public bool alive = true;

    private bool sentDeathMes = false;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (healthPoints <= 0)
        {
            alive = false;
        }

        if (!sentDeathMes && !alive)
        {
            Debug.Log(gameObject.name + " died");
            sentDeathMes = true;
            gameObject.SetActive(false);
        }
    }

}

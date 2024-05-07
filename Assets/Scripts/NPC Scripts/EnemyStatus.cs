using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int hp = 100;
    public int maxHP = 100;
    void Start()
    {
        hp = maxHP;
    }
}

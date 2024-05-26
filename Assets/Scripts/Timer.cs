using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Har en cooldown metod. Skulle kunna ha fler liknande metoder därför namnet Timer
/// </summary>
[Serializable]
public class Timer
{
    [SerializeField] private float cooldownTimeInSec;

    // När cooldownen ska vara klar
    private float cooldownFinishedTime;

    /// <summary>
    /// Kollar om cooldownen är klar
    /// </summary>
    /// <returns>Om den är klar true annars false</returns>
    public bool CooldownFinished()
    {
        if (Time.time < cooldownFinishedTime) return true;
        else return false;
    }
    /// <summary>
    /// Sätter nya cooldownen
    /// </summary>
    public void SetCooldown()
    {
        cooldownFinishedTime = Time.time + cooldownTimeInSec;
    }
}

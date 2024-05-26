using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Har en cooldown metod. Skulle kunna ha fler liknande metoder d�rf�r namnet Timer
/// </summary>
[Serializable]
public class Timer
{
    [SerializeField] private float cooldownTimeInSec;

    // N�r cooldownen ska vara klar
    private float cooldownFinishedTime;

    /// <summary>
    /// Kollar om cooldownen �r klar
    /// </summary>
    /// <returns>Om den �r klar true annars false</returns>
    public bool CooldownFinished()
    {
        if (Time.time < cooldownFinishedTime) return true;
        else return false;
    }
    /// <summary>
    /// S�tter nya cooldownen
    /// </summary>
    public void SetCooldown()
    {
        cooldownFinishedTime = Time.time + cooldownTimeInSec;
    }
}

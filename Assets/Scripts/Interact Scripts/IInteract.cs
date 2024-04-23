using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Så jag slipper skriva massa olika if-satser för varje typ av interaction
/// </summary>
public interface IInteract
{
    /// <summary>
    /// Stoppa in en funktion här istället för att stoppa in det direkt i "Better Interact".
    /// </summary>
    void Interact();
}
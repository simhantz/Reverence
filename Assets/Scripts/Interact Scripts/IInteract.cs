using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// S� jag slipper skriva massa olika if-satser f�r varje typ av interaction
/// </summary>
public interface IInteract
{
    /// <summary>
    /// Stoppa in en funktion h�r ist�llet f�r att stoppa in det direkt i "Better Interact".
    /// </summary>
    void Interact();
}
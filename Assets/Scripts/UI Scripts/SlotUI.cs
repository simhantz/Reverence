using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// H�ller koll p� vilken sprite som ska visas. Ska sitta p� varje Slot
/// </summary>
public class SlotUI : MonoBehaviour
{
    [HideInInspector] public Image image;
    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = null;
    }
}

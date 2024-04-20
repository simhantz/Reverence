using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [HideInInspector] public Image image;
    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = null;
    }
}

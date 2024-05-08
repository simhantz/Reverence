using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Håller koll på vilken sprite som ska visas. Ska sitta på varje Slot
/// </summary>
public class SlotUI : MonoBehaviour
{
    [HideInInspector] public Image image;
    [HideInInspector] public TextMeshProUGUI textMesh = null;

    void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = null;

        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        if (textMesh != null)
        {
            textMesh.enabled = false;
        }
        else Debug.Log("There was no textMesh on " + gameObject.transform.parent.transform.parent.transform.parent.name);
    }
}

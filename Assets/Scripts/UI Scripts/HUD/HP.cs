using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{

    // tror inte den anv��nds
    public Action onHealthChange;

    private TextMeshProUGUI _tmp;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        // Updaterar HUD:n konstant. Inte optimalt men det blev s� nu
        _tmp.text = $"{Global.PlayerStatus.healthPoints.ToString()}/{Global.PlayerStatus.maxHealthPoints.ToString()}";
    }


}

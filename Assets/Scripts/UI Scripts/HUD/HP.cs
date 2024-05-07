using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HP : MonoBehaviour
{
    public Action onHealthChange;

    private TextMeshProUGUI _tmp;

    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        _tmp.text = $"{PlayerStatus.HP.ToString()}/{PlayerStatus.MaxHP.ToString()}";
    }


}

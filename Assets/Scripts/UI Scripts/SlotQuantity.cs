using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotQuantity : MonoBehaviour
{
    private ChestUI chest = null;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Awake()
    {
        chest = GetComponentInParent<ChestUI>();
        text = GetComponent<TextMeshProUGUI>();

        if (chest == null)
        {
            Debug.Log("IS NULLLLLLLLL!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

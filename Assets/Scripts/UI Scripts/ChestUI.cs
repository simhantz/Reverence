using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestUI : UI
{
    [SerializeField] private InventoryManager chest = null;

    // Start is called before the first frame update
    void Start()
    {
        if (chest != null)
        {
            inventoryManager = chest;
        }
        SetPanel(this.gameObject);
        GetIconsArray(panel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

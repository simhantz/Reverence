using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public InventoryManager inventory;
    public Image newImage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (newImage != null)
        {
            newImage.enabled = true;
        }
        else newImage.enabled = false;
        newImage.sprite = inventory.inventory[0].itemIcon;
    }
}

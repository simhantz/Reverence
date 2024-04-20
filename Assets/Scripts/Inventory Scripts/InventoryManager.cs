using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemInstance> inventory = new();

    public ItemData testItem;

    private void Awake()
    {
        TestItemAdd(testItem);
    }
    public void TestItemAdd(ItemData data)
    {
        if (data != null)
        {
            ItemInstance myItem = new ItemInstance(data);
            AddItem(myItem);
        }
    }
    public void AddItem(ItemInstance item)
    {
        Debug.Log("Added " +  item.itemName + " to a inventory");
        inventory.Add(item);
    }
    public void TransferTo(InventoryManager target)
    {
        Debug.Log($"Transferred {inventory[0].itemName} to {target.name}");
        target.AddItem(inventory[0]);
        inventory.RemoveAt(0);
    }
    public void TakeAll(InventoryManager target)
    {
        foreach (ItemInstance item in target.inventory.ToList())
        {
            AddItem(item);
            target.inventory.Remove(item);
        }
    }
}

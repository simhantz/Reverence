using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    public Action onInventoryUpdate;

    public List<ItemInstance> listOfItems = new();

    public ItemData testItem;

    public int listSize = 18;

    private int lastListCount;

    private void Start()
    {
        TestItemAdd(testItem);
    }
    private void Update()
    {
        ListUpdate(lastListCount);
        lastListCount = listOfItems.Count;
    }
    public void AddItem(ItemInstance item)
    {
        if (listOfItems.Count < listSize)
        {
            //if (listOfItems.Contains(item))
            //{
            //    ItemInstance result = listOfItems.Find(x => x == item);
            //    result.itemAmount += 1;
            //}
            //else
            //{
            //    Debug.Log("Added " + item.itemName + " to a inventory");
            //    listOfItems.Add(item);
            //}

            Debug.Log("Added " + item.itemName + " to a inventory");
            listOfItems.Add(item);

        }
        else Debug.Log("Inventory is full");
    }
    public void TestItemAdd(ItemData data)
    {
        if (data != null)
        {
            ItemInstance myItem = new ItemInstance(data);
            AddItem(myItem);
        }
    }
    public void TransferTo(InventoryManager target)
    {
        Debug.Log($"Transferred {listOfItems[0].itemName} to {target.name}");
        target.AddItem(listOfItems[0]);
        listOfItems.RemoveAt(0);
    }
    public void TakeAll(InventoryManager target)
    {
        foreach (ItemInstance item in target.listOfItems.ToList())
        {
            AddItem(item);
            target.listOfItems.Remove(item);
        }
    }
    private void ListUpdate(int lastListCount = 0)
    {
        if (lastListCount != listOfItems.Count && onInventoryUpdate != null)
        {
            onInventoryUpdate();
        }
    }
}

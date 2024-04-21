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

    public int listCapacity = 18;

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
    public void AddItem(ItemInstance itemInstance)
    {
        if ((listOfItems.Count < listCapacity) == false)
        {
            Debug.Log("Inventory is full");
            return;
        }
        if (listOfItems.Count == 0) 
        {
            Debug.Log("Added " + itemInstance.name + " to a inventory");
            listOfItems.Add(itemInstance);
            return;
        }
        //foreach (ItemInstance checker in listOfItems)
        //{
        //    if (checker.originalItem == itemInstance.originalItem)
        //    {
        //        Debug.Log("Contains One Version of This Item: " + itemInstance.itemName);
        //        checker.itemAmount += 1;

        //    }
        //    else
        //    {
        //        Debug.Log("Added " + itemInstance.itemName + " to a inventory");
        //        listOfItems.Add(itemInstance);
        //    }

        //}
        for (int i = 0; i < listOfItems.Count; i++)
        {
            //if (listOfItems[i] == itemInstance == itemInstance.originalData)
            //{
            //    Debug.Log("Contains One Version of This Item: " + itemInstance.name);
            //    listOfItems[i].amountOf += 1;
            //    return;
            //}
            if (listOfItems[i].originalData == itemInstance.originalData && itemInstance.originalData != null)
            {
                Debug.Log("Contains One Version of This Item: " + itemInstance.name);
                listOfItems[i].amountOf += itemInstance.amountOf;
                return;
            }
        }
        Debug.Log("Added " + itemInstance.name + " to a inventory");
        listOfItems.Add(itemInstance);

        

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
        Debug.Log($"Transferred {listOfItems[0].name} to {target.name}");
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

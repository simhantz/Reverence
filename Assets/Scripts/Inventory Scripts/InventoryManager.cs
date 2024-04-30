using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

/// <summary>
/// Hanterar Inventories och h�ller det mesta
/// </summary>
[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    // En delegate s� jag kan s�tta in funktioner fr�n andra script
    public Action onInventoryUpdate;

    [SerializeField] private readonly int _listCapacity = 18;

    // testar bara att l�gga in n�got i listan
    [SerializeField] private ItemData testItem;

    public List<ItemInstance> listOfItems = new();

    private int _lastListCount;

    private void Start()
    {
        TestItemAdd(testItem);
    }
    private void Update()
    {
        ListUpdate(_lastListCount);
    }

    // L�gger till test saken
    public void TestItemAdd(ItemData data)
    {
        if (data != null)
        {
            ItemInstance myItem = new ItemInstance(data);
            AddItem(myItem);
        }
    }

    /// <summary>
    /// Kollar om listan har �ndrats och uppdaterar UI:n
    /// </summary>
    /// <param name="lastListCount">asdasdasdasds</param>
    private void ListUpdate(int lastListCount = 0)
    {
        if (lastListCount != listOfItems.Count && onInventoryUpdate != null)
        {
            onInventoryUpdate();
        }
        _lastListCount = listOfItems.Count;
    }

    /// <summary>
    /// L�gger till i listan om det finns plats eller i en stack
    /// </summary>
    /// <param name="itemInstance">Saken som ska in</param>
    /// <returns>En bool om den lyckades l�gga in saken</returns>
    public bool AddItem(ItemInstance itemInstance)
    {
        // Finns det plats?
        if ((listOfItems.Count < _listCapacity) == false)
        {
            Debug.Log("Inventory is full");
            return false;
        }

        // Om inventory �r tomt sl�nger vi in saken och skiter i det andra
        if (listOfItems.Count == 0) 
        {
            Debug.Log("Added " + itemInstance.name + " to a inventory");
            listOfItems.Add(itemInstance);
            return true;
        }
        
        // Finns det redan en s�dan sak i inventory, �ka stack-sizen ist�llet
        for (int i = 0; i < listOfItems.Count; i++)
        {
            if (listOfItems[i].originalData == itemInstance.originalData && itemInstance.originalData != null)
            {
                Debug.Log("Contains One Version of This Item: " + itemInstance.name);
                listOfItems[i].amountOf += itemInstance.amountOf;
                return true;
            }
        }

        // Om den har kommit hit s� �r det ett nytt item som ska l�ggas in
        Debug.Log("Added " + itemInstance.name + " to a inventory");
        listOfItems.Add(itemInstance);
        return true;
    }
    /// <summary>
    /// Tar en sak fr�n target inventory fr�n den metoden blev kallad ifr�n
    /// </summary>
    /// <param name="target">Vart den ska ge</param>
    /// <param name="indexPosition">Vilket element den ska ta ifr�n, 0 by default</param>
    public void TransferTo(InventoryManager target, int indexPosition = 0)
    {

    }

    /// <summary>
    /// Ger en sak fr�n target inventory fr�n den metoden blev kallad ifr�n
    /// </summary>
    /// <param name="target">Vartifr�n den tar ifr�n</param>
    /// <param name="indexPosition">Vilket element den ska ta ifr�n, 0 by default</param>
    public void TransferFrom(InventoryManager target, int indexPosition = 0)
    {
        if (target.listOfItems.Count == 0 || target.listOfItems.Count < indexPosition || indexPosition == (-1) )
        {
            Debug.Log("No make sense index. From " + gameObject.name);
            return ;
        }

        bool addedItem = AddItem(target.listOfItems[indexPosition]);
        if (addedItem)
        {
            target.listOfItems.Remove(target.listOfItems[indexPosition]);
        }
    }

    /// <summary>
    /// Tar allt fr�n target
    /// </summary>
    /// <param name="target">Vartifr�n den tar ifr�n</param>
    public void TakeAll(InventoryManager target)
    {
        foreach (ItemInstance item in target.listOfItems.ToList())
        {
            bool addedItem = AddItem(item);
            if (addedItem)
                target.listOfItems.Remove(item);
        }
    } 
}

using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    public List<InventoryItem>[] inventoryLists;

    [HideInInspector] // the index of the array is the inventory list (from the InventoryLocation enum), and the value is the capacity of that inventory list;
    public int[] inventoryListCapacityIntArray;
    

    [SerializeField]
    private SO_ItemList itemList = null;

    protected override void Awake()
    {
        base.Awake();

        CreateInventoryLists();

        CreateItemDetailsDictionary();
    }

    private void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLoaction.Count];
        for(int i = 0; i < (int)InventoryLoaction.Count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }

        inventoryListCapacityIntArray = new int[(int)InventoryLoaction.Count];
        inventoryListCapacityIntArray[(int)InventoryLoaction.Player] = Settings.playerInitialInventoryCapacity;
    }

    /// <summary>
    /// Add an item to the inventory list for the inventoryLocation
    /// </summary>
    /// <param name="inventoryLocation"></param>
    /// <param name="item"></param>
    public void AddItem(InventoryLoaction inventoryLocation, Item item)
    {
        int itemCode = item.ItemCode;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];
        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);
        if (itemPosition != -1) AddItemAtPosition(inventoryList, itemCode, itemPosition);
        else AddItemAtPosition(inventoryList, itemCode);
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    public void AddItem(InventoryLoaction inventoryLocation, Item item, GameObject gameObjectToDelete)
    {
        AddItem(inventoryLocation, item);
        Destroy(gameObjectToDelete);
    }

    /// <summary>
    /// Add item to the end of the inventory
    /// </summary>
    /// <param name="inventoryList"></param>
    /// <param name="itemCode"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem inventoryItem = new InventoryItem(); 
        inventoryItem.itemCode = itemCode;
        inventoryItem.itenQuantity = 1;
        inventoryList.Add(inventoryItem);

        //DebugPrintInventoryList(inventoryList);
    }

    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int itemPosition)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[itemPosition].itenQuantity + 1;
        inventoryItem.itenQuantity = quantity;
        inventoryItem.itemCode = itemCode;
        inventoryList[itemPosition] = inventoryItem;

        Debug.ClearDeveloperConsole();
        //DebugPrintInventoryList(inventoryList);
    }


    //private void DebugPrintInventoryList(List<InventoryItem> inventoryList)
    //{
    //    foreach (InventoryItem item in inventoryList)
    //    {
    //        Debug.Log("Item description : " + InventoryManager.Instance.GetItemDetails(item.itemCode).itemDescription + "  Item Quantity: " + item.itenQuantity);
    //    }
    //    Debug.Log("*********************************************************************");
    //}

    /// <summary>
    /// Find if an itemCode  is already in the inventory. Returns the item position
    /// in the inentory list, or -1 if the item is not in the inventory.
    /// </summary>
    /// <param name="inventoryLocation"></param>
    /// <param name="itemCode"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private int FindItemInInventory(InventoryLoaction inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        for(int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemCode == itemCode) return i;
        }
        return -1;
    }

    private void Start()
    {
        // Create item detials dcitionary
        //CreateItemDetailsDictionary();
    }
    /// <summary>
    /// Populates the itemDtailsDictionary from the scriptable object items list
    /// </summary>
    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach(ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    /// <summary>
    /// Returns the itemDetails (from the SO_ItemList) for the itemCode, or null if the item code doesn't exist
    /// </summary>
    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;
        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        }
        return null;
    }

    public void RemoveItem(InventoryLoaction inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);
        if (itemPosition != -1) RemoveItemAtPosition(inventoryList, itemCode, itemPosition);
        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    private void RemoveItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int itemPosition)
    {
        //throw new NotImplementedException();
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[itemPosition].itenQuantity - 1;

        if(quantity > 0)
        {
            inventoryItem.itenQuantity = quantity;
            inventoryItem.itemCode = itemCode;
            inventoryList[itemPosition] = inventoryItem;
        }
        else
        {
            inventoryList.RemoveAt(itemPosition);
        }
    }

    public void SwapInventoryItems(InventoryLoaction inventoryLoaction, int fromItem, int toItem)
    {
        if(fromItem < inventoryLists[(int)inventoryLoaction].Count && toItem < inventoryLists[(int)inventoryLoaction].Count
            && fromItem != toItem && fromItem >= 0 && toItem >= 0)
        {
            InventoryItem fromInventoryItem = inventoryLists[(int)inventoryLoaction][fromItem];
            InventoryItem toInventoryItem = inventoryLists[(int)inventoryLoaction][toItem];

            inventoryLists[(int)inventoryLoaction][toItem] = fromInventoryItem;
            inventoryLists[(int)inventoryLoaction][fromItem] = toInventoryItem;

            EventHandler.CallInventoryUpdatedEvent(inventoryLoaction, inventoryLists[(int)inventoryLoaction]);

        }
    }
}
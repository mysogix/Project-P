using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem current;
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionairy;
    public List<InventoryItem> inventory;
    public InventoryUI inventoryUI;

    private void Awake()
    {
        // Prüfen, ob bereits eine Instanz existiert und dann sicherstellen, dass nur eine Instanz existiert
        if (current != null && current != this)
        {
            Destroy(gameObject); // Zerstöre doppelte Instanzen
        }
        else
        {
            current = this;
            DontDestroyOnLoad(gameObject);  // Markiere das GameObject als persistent
            inventory = new List<InventoryItem>();
            m_itemDictionairy = new Dictionary<InventoryItemData, InventoryItem>();
        }
    }

    [Serializable]
    public class InventoryItem
    {
        public InventoryItemData data;
        public int stackSize;

        public InventoryItem(InventoryItemData source)
        {
            data = source;
            AddToStack();
        }

        public void AddToStack()
        {
            stackSize++;
        }

        public void RemoveFromStack()
        {
            stackSize--;
        }
    }

    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionairy.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    [Obsolete]
    public void Add(InventoryItemData referenceData)
    {
        if (m_itemDictionairy.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionairy.Add(referenceData, newItem);
        }

        if (inventoryUI != null && inventoryUI.gameObject.activeSelf)
        {
            inventoryUI.RefreshInventory();
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (m_itemDictionairy.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionairy.Remove(referenceData);
            }
        }

        if (inventoryUI != null && inventoryUI.gameObject.activeSelf)
        {
            inventoryUI.RefreshInventory();
        }
    }
}

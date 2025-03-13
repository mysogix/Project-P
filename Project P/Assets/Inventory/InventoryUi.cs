using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject inventorySlotPrefab;
    public Transform itemGrid;
    public Button openInventoryButton;
    public Button closeInventoryButton;

    private void Start()
    {
        // Anfangszustand
        inventoryPanel.SetActive(false);
        closeInventoryButton.gameObject.SetActive(false);

        openInventoryButton.onClick.AddListener(OpenInventory);
        closeInventoryButton.onClick.AddListener(CloseInventory);
    }

    private void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        openInventoryButton.gameObject.SetActive(false);
        closeInventoryButton.gameObject.SetActive(true);

        RefreshInventory();
    }

    private void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        openInventoryButton.gameObject.SetActive(true);
        closeInventoryButton.gameObject.SetActive(false);
    }

    public void RefreshInventory()
    {
        // Vorhandene Slots entfernen
        foreach (Transform child in itemGrid)
        {
            Destroy(child.gameObject);
        }

        // Inventar-Items anzeigen
        foreach (var item in InventorySystem.current.inventory)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, itemGrid);
            Image icon = slot.GetComponentInChildren<Image>();

            if (icon != null)
            {
                icon.sprite = item.data.icon;
            }
        }
    }
}


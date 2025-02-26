using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public static ItemObject current;

    public void Update()
    {
        current = this;
    }

    public void OnHandlePickupItem()
    {
        if (referenceItem == null)
        {
            Debug.LogError($"Fehler: referenceItem ist null! GameObject: {gameObject.name}");
            return;
        }

        Debug.Log($"Item aufgenommen: {referenceItem.displayName}");
        InventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }

}

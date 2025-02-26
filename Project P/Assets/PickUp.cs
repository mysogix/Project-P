using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnMouseDown()
    {
        ItemObject item = GetComponent<ItemObject>();

        if (item != null)
        {
            item.OnHandlePickupItem();
        }
    }
}


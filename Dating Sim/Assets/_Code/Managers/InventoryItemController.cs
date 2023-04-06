using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;
    CharacterInfo character;
    Player player;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void GiftItem(Item itemToGift, CharacterInfo characterToGiftTo)
    {
        RemoveItem();
        //Player.Instance.GainMoney();
    }
}

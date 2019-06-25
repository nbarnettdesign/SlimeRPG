using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public Item item;

    public Image icon;
    public Button removeButton;
    public TextMeshProUGUI stackNumber;
    public int textAmount;
    public bool isAvailable;


    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        stackNumber.text = item.stackNumber.ToString();
        if (stackNumber.text == "1" || stackNumber.text == "0")
        {
            stackNumber.text = "";
        }
    }

    public void ClearSlot ()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        stackNumber.text = "";


    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }



}

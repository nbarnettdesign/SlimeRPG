using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton

    public static InventoryManager instance;
    public bool absorbing;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
        }
        instance = this;
    }

    #endregion
    InventorySlot[] slots;
    public Transform itemsParent;
    List<InventorySlot> availableSlots;

    private void Start()
    {
        availableSlots = new List<InventorySlot>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].isAvailable == true)
            {
                availableSlots.Add(slots[i]);
            }
            i++;
        }

    }

    //Set how many are locked/available
    //have list of how many slots are free/in use
    //Saves name of each slot item to check if stackable
    void UpdateAvailableSlots()
    {
        availableSlots = new List<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isAvailable == true)
            {
                availableSlots.Add(slots[i]);
            }
            i++;
        }

    }


    public bool ItemIncoming(Item itemBeingPickedUp)
    {
        //false should probably display in world somehow

        //check if item is stackable
        if (itemBeingPickedUp.isStackable == true)
        {
            //for every available slot (slot that is unlocked and not maxed out)
            for (int i = 0; i < availableSlots.Count; i++)
            {
                //if the item in the slot has the same name
                if(availableSlots[i].item.name == itemBeingPickedUp.name)
                {
                    //if max stack number on item is less than however many is in there plus the amount coming in
                    if(availableSlots[i].item.maxStackNumber <= availableSlots[i].item.stackNumber + itemBeingPickedUp.stackNumber)
                    {
                        //The number of the item on the pickup(eg 7)
                        //is minused but the max stack number (eg 10)
                        //minus the amount already stacked (eg 4) so 10-4 = 6, 7-6 = 1 so stack left = 1
                        itemBeingPickedUp.stackNumber -= (availableSlots[i].item.maxStackNumber - availableSlots[i].item.stackNumber);
                        if (itemBeingPickedUp.stackNumber == 0)
                        {
                            //if its 0 it destroys it, if not then the number is changed and it continues to exist
                            return true;
                        }
                        else return false;
                    }
                    else
                    {
                        //
                        availableSlots[i].item.stackNumber += itemBeingPickedUp.stackNumber;
                        return true;
                    }

                }
            }


        }
        else if (itemBeingPickedUp.isStackable == false)
        {

        }
        return false;
        //Check item if stackable
        //if yes Search available Item slots to see if it can be added to a stack
        //if no, check if free slot

        //if yes search current used slots for name, if no, check if any slots free, if no, no pickup
        //if yes, assign to slot
    }

    void DropItem() 
    { 
        //Remove from slot
        //spawn item in world at player (Steal random drop position code from chest)
        //give item that spawns the same stack
    }

    //eat still needs to be connected to pickups
    public bool Eat(Item item)
    {
        if (absorbing)
        {
            return true;
        }
        return false;

    }






    //for ITEM SLOT SCRIPT
    //needs Icon, Drop button, Stack Number, UI FOR ALL
    //Item its holding ****
    //if available or not
    //not available if locked or if reached stack max amount.

    //For ITEMS SPECIFICALLY
    // is stackable bool
    //max stack size otherwise.
    //maybe add a grab items in area when dropped that are same as it and add it to pile
}

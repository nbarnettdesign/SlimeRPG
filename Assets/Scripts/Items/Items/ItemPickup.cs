
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public bool wasEaten;
    public bool wasPickedUp;
    public bool notPickupable; 

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {

        wasEaten = Inventory.instance.Eat(item);
        if (!wasEaten && !notPickupable)
        {
            wasPickedUp = Inventory.instance.Add(item);
        }

        if (wasPickedUp)
        {
            Debug.Log("Picking up " + item.name);
            Destroy(gameObject);
        }
        if (wasEaten)
        {
            Debug.Log("Eating " + item.name);
            PlayerExp.instance.Absorb(this);
            Destroy(gameObject);
        }


    }

}

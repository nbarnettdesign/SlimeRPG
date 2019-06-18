using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlot : Interactable
{
    public bool filled = false;
    public GameObject food;
    GameObject grownFood;

    public override void Interact()
    {
        base.Interact();

        Farm();

    }


    void Farm()
    {
        if (!filled)
        {
            grownFood = Instantiate(food, this.transform) as GameObject;
            filled = true;
            grownFood.GetComponent<Crops>().farmPlot = this.gameObject;
        }
    }

}

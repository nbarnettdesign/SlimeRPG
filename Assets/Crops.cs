using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : Interactable
{
    public float timeToGrow;
    float growthTimer;
    bool finishedGrowing;
    public GameObject farmPlot;




    private void Start()
    {
        growthTimer = 0;
    }

    private void Update()
    {
        if (!finishedGrowing)
        {
            if (growthTimer <= timeToGrow)
            {
                growthTimer += Time.deltaTime;
                this.gameObject.transform.localScale = new Vector3((growthTimer / timeToGrow), (growthTimer / timeToGrow), (growthTimer / timeToGrow));
            }
            else
            {
                finishedGrowing = true;
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    public override void Interact()
    {
        base.Interact();

        Harvest();

    }

    void Harvest()
    {
        if (finishedGrowing)
        {
            Debug.Log("COOOORN");
            farmPlot.GetComponent<FarmPlot>().filled = false;
            //Add Corn to inventory
            Destroy(this.gameObject);
        }
    }
}

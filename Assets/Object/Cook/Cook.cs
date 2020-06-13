using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : SupplyTable
{
    public float CookingCD;

    private float CookingTimer = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (CookingTimer <= 0)
            Cooking();
        else
            CookingTimer -= Time.fixedDeltaTime;
    }

    private void Cooking()
    {
        CookingTimer = CookingCD;
        CreateFood();
    }
}

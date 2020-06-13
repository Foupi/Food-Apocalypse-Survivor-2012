using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplier : Character
{
    public SupplyTable StartSupply;
    public SupplyTable EndSupply;

    public float TakeDropSupplyCD;

    public int SupplyCapacity;

    private bool TakingOrDroping = false;
    private bool walkingToEnd = false;

    private readonly List<SupplyFood> foods = new List<SupplyFood>();
    private float TakeDropTimer;

    // Update is called once per frame
    void Update()
    {
        if (walkingToEnd)
            Move(EndSupply.transform.position - transform.position);
        else
            Move(StartSupply.transform.position - transform.position);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out SupplyTable supply))
        {
            if (supply == StartSupply)
            {
                if (foods.Count < SupplyCapacity)
                {
                    SupplyFood food = supply.Take();
                    if (food != null)
                    {
                        food.Grab(transform);
                        foods.Add(food);
                    }
                }
                else
                    walkingToEnd = true;
            }
            if (supply == EndSupply)
            {
                while (foods.Count > 0 && EndSupply.Drop(foods[foods.Count - 1])) 
                    foods.RemoveAt(foods.Count - 1);
                if (foods.Count == 0)
                    walkingToEnd = false;
            }
        }
    }
}

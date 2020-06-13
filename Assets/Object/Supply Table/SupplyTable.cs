using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyTable : MonoBehaviour
{
    public Transform[] Plates;
    public SupplyFood FoodPrefab;
    public int NumberFoodStart;
    public int MaxFood;
    public float sizeFoodFloor;

    private readonly List<SupplyFood> supplies = new List<SupplyFood>();

    private void Start()
    {
        for(int i = 0; i < NumberFoodStart; i++)
        {
            SupplyFood food = Instantiate(FoodPrefab);
            supplies.Add(food);
            food.PutOnPlate(FindPlate(), this);
        }
    }


    private Vector3 FindPlate()
    {
        return Plates[supplies.Count % Plates.Length].position + 
            Vector3.up * (sizeFoodFloor * (supplies.Count / Plates.Length));
    }

    public SupplyFood Take()
    {
        if (supplies.Count == 0)
            return null;
        int end = supplies.Count - 1;
        SupplyFood food = supplies[end];
        supplies.RemoveAt(end);
        return food;
    }
}

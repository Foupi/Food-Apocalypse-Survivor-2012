using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyTable : MonoBehaviour
{
    public Transform[] Plates;
    public SupplyFood FoodPrefab;
    public int NumberFoodStart;
    public int MaxFood;

    private readonly List<SupplyFood> supplies = new List<SupplyFood>();

    private void Start()
    {
        for(int i = 0; i < NumberFoodStart; i++)
        {
            supplies.Add(Instantiate(FoodPrefab, findPlate(), Quaternion.identity));
        }
    }


    private Vector3 findPlate()
    {
        return Plates[supplies.Count % Plates.Length].position;
    }
}

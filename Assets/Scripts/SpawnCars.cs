using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : SpawnObjects
{
    public List<GameObject> cars;
    
    private System.Random rand;

    void Start()
    {
        base.Start();
        rand = new System.Random();
    }

    override protected GameObject GetObject(Transform tr)
    {
        var chance = 1.0 / cars.Count;
        GameObject carPrefab = null;

        foreach(GameObject car in cars)
        {
            if(rand.NextDouble() <= chance)
            {
                carPrefab = car;
                break;
            }
        }

        if(carPrefab == null)
        {
            carPrefab = cars[0];
        }

        var car2 = Instantiate(carPrefab, tr.position, Quaternion.identity);

        return car2;
    }

    override protected GameObject[] GetAllObjects()
    {
        return GameObject.FindGameObjectsWithTag("Car");
    }
}

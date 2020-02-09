using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : SpawnObjects
{
    public GameObject objectPersonMaker;
    private UpgradeVisualizer visual;

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        visual = objectPersonMaker.GetComponent<UpgradeVisualizer>();
    }

    override protected GameObject GetObject(Transform tr)
    {
        return visual.GetPerson(tr);
    }

    override protected GameObject[] GetAllObjects()
    {
        return GameObject.FindGameObjectsWithTag("Person");
    }
}

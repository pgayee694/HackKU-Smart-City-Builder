using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

abstract public class SpawnObjects : MonoBehaviour
{
    public float secondsToSpawn;
    public int maximumObjects;

    private List<Transform> spawns;
    private System.Random rand;
    private float timeToSpawn;

    // Start is called before the first frame update
    protected void Start()
    {
        spawns = new List<Transform>();
        foreach(Transform child in transform)
        {
            spawns.Add(child);
        }
        rand = new System.Random();
        timeToSpawn = Time.time + secondsToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            if(GetAllObjects().Length < maximumObjects)
            {
                Spawn();
            }
            timeToSpawn = Time.time + secondsToSpawn;
        }
    }

    void Spawn()
    {
        var spawnLocation = GetRandomSpawn();
        Transform gotoLocation = null;

        while(gotoLocation == null)
        {
            gotoLocation = GetRandomSpawn();
            if(gotoLocation == spawnLocation)
            {
                gotoLocation = null;
            }
        }

        var obj = GetObject(spawnLocation);
        obj.GetComponent<NavMeshAgent>().updateRotation = false;
        obj.GetComponent<NavMeshAgent>().SetDestination(gotoLocation.position);
    }

    abstract protected GameObject GetObject(Transform tr);

    Transform GetRandomSpawn()
    {
        var index = rand.Next(spawns.Count);
        return spawns[index];
    }

    abstract protected GameObject[] GetAllObjects();
}

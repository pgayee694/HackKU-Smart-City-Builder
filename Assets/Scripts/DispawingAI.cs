using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class DispawingAI : MonoBehaviour
{
    public float despawnDistance;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(agent.destination, transform.position) <= despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}

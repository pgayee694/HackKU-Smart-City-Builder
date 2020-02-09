using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRotation : MonoBehaviour
{
    public GameObject other;
    
    private Transform pivot;

    void Start()
    {
        pivot = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        var myRotation = transform.rotation.eulerAngles;
        var pivotRotation = pivot.rotation.eulerAngles;

        Quaternion qu = Quaternion.identity;
        qu.eulerAngles = new Vector3(pivotRotation.x, myRotation.y, myRotation.z);

        other.transform.rotation = qu;
    }
}

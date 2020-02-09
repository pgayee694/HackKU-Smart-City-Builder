using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical);
        transform.Translate(Vector3.right * horizontal);
    }
}

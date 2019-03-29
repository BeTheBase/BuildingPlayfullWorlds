using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public LineRenderer LineRndr;
    // Use this for initialization
    void Start()
    {
        if(LineRndr == null)
            LineRndr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LineRndr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                LineRndr.SetPosition(1, hit.point);
            }
        }
        else LineRndr.SetPosition(1, transform.forward * 5000);
    }
}

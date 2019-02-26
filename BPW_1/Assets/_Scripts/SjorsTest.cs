using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SjorsTest : MonoBehaviour
{
    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public float range = 100f;
    //private int numberOfObjects = 0;
    public GameObject SpawnCube;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootEarth(Input.mousePosition);
        }
    }

    public void ShootEarth(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        Instantiate(SpawnCube, hit.point + Vector3.up, Quaternion.identity);
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}

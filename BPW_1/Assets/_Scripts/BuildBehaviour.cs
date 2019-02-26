using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBehaviour : MonoBehaviour
{
    public GameObject[] BuildGameObjects;
    public Image[] BuildItemImages;
    public enum Builds { Cube = 1, Stair = 2, Wall = 3 }
    public Builds BuildItems = Builds.Cube;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            BuildItems = Builds.Cube;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            BuildItems = Builds.Stair;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            BuildItems = Builds.Wall;
        else
            BuildItems = Builds.Cube;


    }

    public void ChangeBuildItem()
    {
        
    }
}

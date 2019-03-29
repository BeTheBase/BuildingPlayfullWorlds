using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Puzzles
{
    public class SpecialDoor : AbstractPuzzleBehaviour
    {
        public Material SpecialDoorMaterial;

        public bool Activate = false;

        private string cubeTag = "BlueSuperCube";

        private void Start()
        {
            switch (ColorCubes)
            {
                case Cubes.Blue:
                    cubeTag = "BlueSuperCube";
                    break;
                case Cubes.Red:
                    cubeTag = "RedSuperCube";
                    break;
                case Cubes.Green:
                    cubeTag = "GreenSuperCube";
                    break;
                default:
                    cubeTag = "BlueSuperCube";
                    break;
            }
        }

        private void FixedUpdate()
        {
            if (Activate)
            {
                transform.GetComponent<Renderer>().material = SpecialDoorMaterial;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == cubeTag)
            {
                Activate = true;
            }
        }
    }
}

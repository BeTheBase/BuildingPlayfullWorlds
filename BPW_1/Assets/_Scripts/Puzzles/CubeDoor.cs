using UnityEngine;

namespace Assets._Scripts.Puzzles
{
    public class CubeDoor : AbstractPuzzleBehaviour
    {
        public GameObject[] LerpObjects;

        public Transform[] Destinations;

        public Material NewMaterial;

        public float TravelSpeed = 3.0f;
        public float TimeToWait = 1f;

        public bool Deactivate = true;

        private Vector3[] originalPositions;

        private bool activate = false;
        private bool isLonger = false;

        private string cubeTag = "BlueSuperCube";

        private void Start()
        {
            if (NewMaterial != null)
            {
                foreach (GameObject lerpObj in LerpObjects)
                {
                    lerpObj.GetComponent<Renderer>().material = NewMaterial;
                }
            }

            originalPositions = new Vector3[LerpObjects.Length];

            for (int index = 0; index < LerpObjects.Length; index++)
            {
                originalPositions[index] = LerpObjects[index].transform.position;
            }

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
            if (LerpObjects == null || Destinations == null)
                return;

            if (activate)
            {
                if (Deactivate)
                {
                    for (int index = 0; index < LerpObjects.Length; index++)
                    {
                        LerpTowardsDestiny(LerpObjects[index], Destinations[index], TravelSpeed);
                    }
                    StartCoroutine(DeactivateAfterTime(this.gameObject, LerpObjects, Destinations, TimeToWait));
                }
                if (!Deactivate)
                {
                    for (int index = 0; index < LerpObjects.Length; index++)
                    {
                        LerpPingPong(LerpObjects[index], originalPositions[index], Destinations[index], TravelSpeed);
                    }
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == cubeTag)
            {
                activate = true;
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerCube : AbstractPlayerBehaviour
    {
        public bool CanShoot = false;
        public float ShootSpeed;
        public float RayLength = 100f;

        public List<GameObject> SuperCubes;
        
        private Rigidbody superBody;
        private Item item;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && CanShoot && SuperCube != null)
                FireCube();

            if (Input.GetMouseButtonDown(1))
                GetCubeBack();

            // If we press left mouse
            if (Input.GetMouseButtonDown(0))
            {
                // Shoot out a ray
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, RayLength))
                {
                    Focus = null;
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && SuperCube != null)
            {
                SuperCubes.Add(SuperCube);
                superBody = SuperCube.GetComponent<Rigidbody>();
                SetFocus(SuperCube.GetComponent<Interactable>());
                CanShoot = true;
                superBody.constraints = RigidbodyConstraints.FreezeAll;

                /* Shoot out a ray
               Ray ray = cam.ScreenPointToRay(Input.mousePosition);
               //Ray ray = new Ray(transform.position, transform.forward);
               RaycastHit hit;

               If we hit
               if (Physics.Raycast(ray, out hit, RayLength))
               {
                   if (hit.collider.name != "SuperCube")
                       SetFocus(hit.collider.GetComponent<Interactable>());
               }*/
            }
        }

        private void FireCube()
        {
            var supercube = SuperCubes.Find(S => S.activeSelf == true);

            /*SuperCube.gameObject.SetActive(true);
            for(int index = 0; index < transform.GetChild(1).childCount; index++)
            {
                if (transform.GetChild(1).GetChild(index).gameObject.activeSelf == true)
                    SuperCube = transform.GetChild(1).GetChild(index).gameObject;
            }*/

            superBody = supercube.GetComponent<Rigidbody>();
            supercube.transform.parent = null;
            superBody.constraints = RigidbodyConstraints.None;
            superBody.AddForce(transform.forward * ShootSpeed, ForceMode.Impulse);
            Inventory.Instance.Remove(item);
        }

        private void GetCubeBack()
        {
            var lastFiredSuberCube = SuperCubes.FindAll(S => S.transform.parent == null);
            foreach(GameObject cube in lastFiredSuberCube)
            {
                SetFocus(cube.GetComponent<Interactable>());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "SuperCube")
            {
                //When we are in range of a SuberCube object set pickup image feedback on active
                PickUpImage.SetActive(true);
                //Fill our SuperCube gameobject with the current colliding SuperCube 
                SuperCube = other.gameObject;
                //Set the item of the colliding SuberCube so we can add it and remove it
                item = other.gameObject.GetComponent<ItemPickup>().item;

                //if(superBody != null)
                  //  superBody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //Set pickup feedback image on false
            PickUpImage.SetActive(false);
        }
    }
}

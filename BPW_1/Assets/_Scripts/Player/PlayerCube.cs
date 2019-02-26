using UnityEngine;

namespace Assets._Scripts.Player
{
    public class PlayerCube : AbstractPlayerBehaviour
    {
        public bool CanShoot = false;
        public float ShootSpeed;

        private Rigidbody superBody;
        private Item item;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && CanShoot && SuperCube != null)
                FireCube();
        
            if (Input.GetKeyDown(KeyCode.E) && SuperCube != null)
            {
                superBody = SuperCube.GetComponent<Rigidbody>();

                CanShoot = true;
                SetFocus(SuperCube.GetComponent<Interactable>());
                
                superBody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        private void FireCube()
        {
            SuperCube.transform.parent = null;
            superBody.constraints = RigidbodyConstraints.None;
            superBody.AddForce(transform.forward * ShootSpeed, ForceMode.Impulse);
            CanShoot = false;
            Inventory.Instance.Remove(item);
        }

        private void OnTriggerEnter(Collider other)
        {
            PickUpImage.SetActive(true);
            if (other.gameObject.name == "SuperCube")
            {
                SuperCube = other.gameObject;
                item = other.gameObject.GetComponent<ItemPickup>().item;
                if(superBody != null)
                    superBody.constraints = RigidbodyConstraints.FreezeAll;
                CanShoot = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PickUpImage.SetActive(false);
        }
    }
}

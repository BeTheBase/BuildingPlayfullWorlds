using UnityEngine;

namespace Assets._Scripts.Interactables
{
    public class SuperCubePickup : MonoBehaviour
    {
        public float RayLength = 0.1f;
        public bool IsGrounded = false;

        private Vector3 startPosition;

        private void Start()
        {
            startPosition = this.transform.position;
        }

        private void FixedUpdate()
        {
            CheckGrounded();
            if (IsGrounded)
                transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            if (this.transform.position.y < -10)
                transform.position = startPosition;
        }

        private void CheckGrounded()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, -transform.up);
            //Debug.DrawRay(ray.origin, ray.direction * rayLength);
            // if there is something directly below the player
            IsGrounded = Physics.Raycast(ray, out hit, RayLength);
        }
    }
}

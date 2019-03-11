using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeHandler : AbstractPlayerBehaviour
{
    public List<GameObject> SuperCubes;
    public Transform CubeHand;

    public GameObject HitPoint;


    public float ShootSpeed;

    private bool CanShoot = false;
    private bool InRange = false;
    private bool CanGetBack = false;
    private Item item;
    private GameObject activeCube;
    private Rigidbody activeBody;
    private SuperCubeController superCubeController;
    private int layerToHit;

    private void FixedUpdate()
    {
        activeCube = SuperCubes.Find(S => S.activeSelf == true && S.GetComponent<SuperCubeController>().IsOnHand == true);
        
        if (activeCube)
        {
            layerToHit = LayerMask.GetMask("Default");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            //If we hit
            if (Physics.Raycast(ray, out hit, 100f, layerToHit))
            {
                HitPoint.transform.position = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(0) && CanShoot)
            ShootCube(activeCube);

        if (Input.GetMouseButtonDown(1) && CanGetBack)
            ReturnSuperCube(activeCube);

        if (Input.GetKeyDown(KeyCode.E) && InRange)
            CollectCube(SuperCube);
    }

    private void CollectCube(GameObject _SuperCube)
    {
        //Add the super cube that is in range to the SuperCubes list
        if(!SuperCubes.Contains(_SuperCube))
            SuperCubes.Add(_SuperCube);
        //Set the cubes parent as the CubeHand
        if (CubeHand)
        {
            _SuperCube.transform.parent = CubeHand;
            //Set the cubes local position as the CubeHands position
            _SuperCube.transform.localPosition = CubeHand.localPosition + Vector3.forward;
            //Do the same for the rotation
            _SuperCube.transform.localEulerAngles = CubeHand.localEulerAngles;
        }
        SetFocus(_SuperCube.GetComponent<Interactable>());
        //activeBody = SuperCube.GetComponent<Rigidbody>();
        //activeBody.constraints = RigidbodyConstraints.FreezeAll;
        //When all is set, set the SuperCube GameObject to null
        //SuperCube = null;
        //Set CanShoot to true so we are able to shoot 
        CanShoot = true;
        superCubeController = _SuperCube.GetComponent<SuperCubeController>();
        superCubeController.IsOnHand = true;

    }

    private void ShootCube(GameObject _activeCube)
    {
        if (_activeCube == null) _activeCube = SuperCube;
        superCubeController = _activeCube.GetComponent<SuperCubeController>();
        superCubeController.LastPosition = _activeCube.transform.position;
        superCubeController.SetDestination(HitPoint.transform.position, ShootSpeed);
        //activeBody.constraints = RigidbodyConstraints.None;

        //activeBody.AddForce(activeBody.transform.forward * ShootSpeed, ForceMode.Impulse);
        //activeBody.constraints = RigidbodyConstraints.None;
        
        //activeBody.MovePosition(activeBody.transform.position + direction * ShootSpeed * Time.deltaTime);
        //_activeCube.transform.GetChild(0).GetChild(2).transform.position = HitPoint.transform.position;

        //var parabolaComponent = _activeCube.GetComponent<ParabolaController>();
        //parabolaComponent.FollowParabola();

        _activeCube.transform.parent = null;
        superCubeController.IsOnHand = false;
        Inventory.Instance.Remove(item);
        CanGetBack = true;

    }

    private void ReturnSuperCube(GameObject _activeCube)
    {
        if (_activeCube == null) _activeCube = SuperCube;

        //var parabolaComponent = _activeCube.GetComponent<ParabolaController>();
        //parabolaComponent.Speed *= -1;
        //parabolaComponent.FollowParabola();
        superCubeController = _activeCube.GetComponent<SuperCubeController>();
        superCubeController.StopAllCoroutines();
        //_activeCube.transform.parent = CubeHand;
        //superCubeController.SetDestination(CubeHand.transform.position, ShootSpeed);
        //if(Vector3.Distance(_activeCube.transform.position, CubeHand.transform.position) < 1f) 
        //  SuperCube = _activeCube;
        foreach(GameObject cube in SuperCubes)
        {
            CollectCube(cube);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SuperCube")
        {
            InRange = true;
            //When we are in range of a SuberCube object set pickup image feedback on active
            PickUpImage.SetActive(true);
            //Fill our SuperCube gameobject with the current colliding SuperCube 
            SuperCube = other.gameObject;
            //Set the item of the colliding SuberCube so we can add it and remove it
            item = SuperCube.GetComponent<ItemPickup>().item;

            //if(superBody != null)
            //  superBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Set pickup feedback image on false
        PickUpImage.SetActive(false);
        InRange = false;
    }
}

using UnityEngine;

public class ItemPickup : Interactable
{
    public bool IsWeapon = true;
    public bool IsShootable = true;
    public float GetForce = 1f;
    public Item item;   // Item to put in the inventory if picked up

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    // Pick up the item
    void PickUp()
    {
        //if the item is not yet in the inventory
        if (!Inventory.Instance.Items.Contains(item))
        {
            Debug.Log("Picking up " + item.name);

            Inventory.Instance.Add(item);   // Add to inventory
        }

        if (IsWeapon)
        {
            transform.parent = WeaponHand;
            transform.localPosition = WeaponPickPosition;
            transform.localEulerAngles = WeaponPickRotation;
        }
        else if (IsShootable)
        {
            /*
            transform.parent = WeaponHand;
            transform.localPosition = Vector3.Lerp(transform.position, WeaponPickPosition, GetForce);
            transform.localEulerAngles = WeaponPickRotation;
            //transform.gameObject.SetActive(false);
            **/
        }
        else
        {
            Destroy(gameObject);    // Destroy item from scene
        }
    }

    void Shoot()
    {

    }

}

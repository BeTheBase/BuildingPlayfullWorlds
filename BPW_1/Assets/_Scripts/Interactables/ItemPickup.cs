using UnityEngine;

public class ItemPickup : Interactable
{
    public bool IsWeapon = true;
    public bool IsShootable = true;
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
        Debug.Log("Picking up " + item.name);
        Inventory.Instance.Add(item);   // Add to inventory

        if (IsWeapon)
        {
            transform.parent = WeaponHand;
            transform.localPosition = WeaponPickPosition;
            transform.localEulerAngles = WeaponPickRotation;
        }
        else if (IsShootable)
        {
            transform.parent = WeaponHand;
            transform.localPosition = WeaponPickPosition;
            transform.localEulerAngles = WeaponPickRotation;
        }
        else
        {
            Destroy(gameObject);    // Destroy item from scene
        }
    }

}

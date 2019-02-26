using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject GlobalInventoryUI; // The entire UI
    public Transform ItemsParent; // Parent object of all items

    private Inventory inventory; // Current inventory

    // Start is called before the first frame update
    private void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChangedCallback += UpdateUI;
    }

    // Check if we open or close the inventory
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            GlobalInventoryUI.SetActive(!GlobalInventoryUI.activeSelf);
            UpdateUI();
        }

        //if(GlobalInventoryUI.activeSelf)
            //Cursor.lockState = CursorLockMode.None;
    }
    // Update the inventory UI by adding or clearing items
    private void UpdateUI()
    {
        InventorySlot[] slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.Items.Count)
            {
                slots[i].AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();              
            }
        }
        Debug.Log("UPDATING UI");
    }
}

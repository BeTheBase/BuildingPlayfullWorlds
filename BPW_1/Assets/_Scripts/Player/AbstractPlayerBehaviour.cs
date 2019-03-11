using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractPlayerBehaviour : MonoBehaviour
{
    public GameObject SuperCube; // Cube object we can shoot 
    public Rigidbody RBody; // Rigidbody of the player 
    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged OnFocusChangedCallback;
    public Interactable Focus;  // Our current Focus: Item, Enemy etc.
    public GameObject PickUpImage;

    public Camera cam;				// Reference to our camera




    private void Awake()
    {
        cam = Camera.main;

        if (PickUpImage != null)
            PickUpImage.SetActive(false);
        RBody = GetComponent<Rigidbody>();
    }

    // Set our Focus to a new Focus
    public void SetFocus(Interactable newFocus)
    {
        OnFocusChangedCallback?.Invoke(newFocus);

        // If our Focus has changed
        if (Focus != newFocus && Focus != null)
        {
            // Let our previous Focus know that it's no longer being focused
            Focus.OnDefocused();
        }

        // Set our Focus to what we hit
        // If it's not an interactable, simply set it to null
        Focus = newFocus;

        if (Focus != null)
        {
            // Let our Focus know that it's being focused
            Focus.OnFocused(transform);
        }
    }
}

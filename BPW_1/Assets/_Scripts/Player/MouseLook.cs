using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : AbstractPlayerBehaviour
{
    //Public's
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes Axes = RotationAxes.MouseXAndY;
    public Texture2D CursorImage;

    //Private's
    private float sensitivityX = 5f;
    private float sensitivityY = 5f;

    private float minimumX = 0f;
    private float maximumX = 360f;

    private float minimumY = -30f;
    private float maximumY = 45f;

    private float rotationY = 0f;

    void Start()
    {
        // Make the rigidbody not change rotation
        if (RBody)
            RBody.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (Axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    private void OnGUI()
    {
        Vector3 cursorPosition = Input.mousePosition;
        GUI.DrawTexture(new Rect(cursorPosition.x - 32, Screen.height - cursorPosition.y - 32, 64, 64), CursorImage);
    }
}
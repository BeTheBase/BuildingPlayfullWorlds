using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int SelectedWeapon = 0;

    private void Update()
    {
        var previousSelectedWeapon = SelectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedWeapon >= transform.childCount - 1)
                SelectedWeapon = 0;
            else
                SelectedWeapon++;
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
                SelectedWeapon = transform.childCount - 1;
            else
                SelectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 1)
            SelectedWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 2)
            SelectedWeapon = 2;

        if (previousSelectedWeapon != SelectedWeapon)
            SelectWeapon();
    }

    private void SelectWeapon()
    {
        var index = 0;
        foreach(Transform weapon in transform)
        {
            if (index == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            index++;
        }
    }
}

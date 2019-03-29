using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts.Puzzles;

public class Teleportation : MonoBehaviour
{
    [System.Serializable]
    public class TeleportData
    {
        public string Name;
        public Transform NewLocation;
        public Transform SpecialLocation;
    }

    public List<TeleportData> Teleportdata = new List<TeleportData>();

    private void OnTriggerEnter(Collider other)
    {
        var otherName = other.gameObject.name;
        var teleportInfo = Teleportdata?.Find(td => td.Name.Equals(otherName));
        var specialDoorComponent = other.gameObject.GetComponent<SpecialDoor>();
        if (otherName == teleportInfo?.Name)
        {
            transform.position = teleportInfo.NewLocation.position;
            transform.rotation = teleportInfo.NewLocation.rotation;   
        }
        if (specialDoorComponent)
        {
            if (specialDoorComponent.Activate)
            {
                transform.position = teleportInfo.SpecialLocation.position;
                transform.rotation = teleportInfo.SpecialLocation.rotation;
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [System.Serializable]
    public class TeleportData
    {
        public string Name;
        public Transform NewLocation;
        public Transform OldLocation;
    }

    public List<TeleportData> Teleportdata = new List<TeleportData>();

    private void OnTriggerEnter(Collider other)
    {
        var otherName = other.gameObject.name;
        var teleportInfo = Teleportdata.Find(td => td.Name.Equals(otherName));
        if (otherName == teleportInfo.Name)
        {
            transform.position = teleportInfo.NewLocation.position;
            transform.rotation = teleportInfo.NewLocation.rotation;
        }
    }
}


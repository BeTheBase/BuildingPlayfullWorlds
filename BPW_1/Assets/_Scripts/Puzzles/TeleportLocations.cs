using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeleportLocations : MonoBehaviour
{
    [SerializeField]
    public string Name;
    [SerializeField]
    public Transform NewLocation;
    [SerializeField]
    public Transform OldLocation;

}

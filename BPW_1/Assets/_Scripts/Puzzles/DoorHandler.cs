using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Puzzles
{
    public class DoorHandler : AbstractPuzzleBehaviour
    {
        [System.Serializable]
        public class DoorData
        {
            public int RequiredLocks;
            public int ActivatedLocks;
            public bool UnLockDoor()
            {
                return ActivatedLocks >= RequiredLocks;
            }
            public GameObject DoorObject;
            public GameObject DoorDestiny;
            public Vector3 DoorClosedPosition()
            {
                return DoorObject.transform.position;
            }
            public float TravelSpeed;
            public float TimeToWait;

            public List<CubeDoor> DoorLocks;
        }

        public List<DoorData> Doordata;

        public static DoorHandler Instance;

        private void Update()
        {
            /*
            foreach(DoorData data in Doordata)
            {
                List<bool> activatedBooleans = new List<bool>();

                if (data.UnLockDoor())
                {
                    LerpTowardsDestiny(data.DoorObject, data.DoorDestiny.transform.position, data.TravelSpeed);
                    StartCoroutine(RevertObjectAfterTime(data.DoorObject, data.DoorClosedPosition(), data.TimeToWait, data.TravelSpeed));
                }

                /*
                for(int index = 0; index < data.DoorLocks.Count; index++)
                {
                    activatedBooleans.Add(data.DoorLocks[index].activate);

                    if (activatedBooleans.TrueForAll(b => b))
                        data.ActivatedLocks = data.RequiredLocks;
                }

                foreach(var doorLock in data.DoorLocks)
                {
                    if (doorLock.activate)
                        activatedBooleans.Add(doorLock.activate);

                    foreach(bool activeBool in activatedBooleans)
                        data.ActivatedLocks++;
                }
                
                foreach (CubeDoor doorLocks in data.DoorLocks)
                {
                    if (doorLocks.once)
                    {
                        data.ActivatedLocks++;
                    }
                }*/
                      
        }

        public void UpdateDoors()
        {
            foreach (DoorData data in Doordata)
            {
                List<bool> activatedBooleans = new List<bool>();

                if (data.UnLockDoor())
                {
                    LerpTowardsDestiny(data.DoorObject, data.DoorDestiny.transform.position, data.TravelSpeed);
                    //StartCoroutine(RevertObjectAfterTime(data.DoorObject, data.DoorClosedPosition(), data.TimeToWait, data.TravelSpeed));
                }

                /*
                for(int index = 0; index < data.DoorLocks.Count; index++)
                {
                    activatedBooleans.Add(data.DoorLocks[index].activate);

                    if (activatedBooleans.TrueForAll(b => b))
                        data.ActivatedLocks = data.RequiredLocks;
                }*/

                foreach (var doorLock in data.DoorLocks)
                {
                    if (doorLock.activate)
                        activatedBooleans.Add(doorLock.activate);

                    foreach (bool activeBool in activatedBooleans)
                        data.ActivatedLocks++;
                }
                /*
                foreach (CubeDoor doorLocks in data.DoorLocks)
                {
                    if (doorLocks.once)
                    {
                        data.ActivatedLocks++;
                    }
                }*/
            }
        }

    }
}

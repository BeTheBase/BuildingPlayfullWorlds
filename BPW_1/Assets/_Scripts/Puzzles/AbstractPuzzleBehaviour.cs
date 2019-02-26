﻿using System.Collections;
using UnityEngine;

namespace Assets._Scripts.Puzzles
{
    public abstract class AbstractPuzzleBehaviour : MonoBehaviour
    {
        public enum Cubes { Blue = 0, Red = 1, Green = 2 }
        public Cubes ColorCubes = Cubes.Blue;

        /// <summary>
        /// Lerps a GameObject from his current position towards new destiny with travelSpeed
        /// </summary>
        /// <param name="objToLerp"></param>
        /// <param name="destiny"></param>
        /// <param name="travelSpeed"></param>
        public void LerpTowardsDestiny(GameObject objToLerp, Transform destiny, float travelSpeed)
        {
            objToLerp.transform.position = Vector3.Lerp(objToLerp.transform.position, destiny.position, travelSpeed * Time.deltaTime);
        }

        public void LerpPingPong(GameObject objToLerp, Vector3 originalPosition, Transform destinty, float travelSpeed)
        {
            var timer = 0f;
            timer += Time.deltaTime;
            objToLerp.transform.position = Vector3.Lerp(originalPosition, destinty.position, Mathf.PingPong(Time.time * travelSpeed, 1.0f));
        }

        /// <summary>
        /// Deactivate GameObjects in array 
        /// </summary>
        /// <param name="lerpObjects"></param>
        /// <param name="destinations"></param>
        /// <param name="timeToWait"></param>
        /// <returns></returns>
        public IEnumerator DeactivateAfterTime(GameObject controlObj, GameObject[] lerpObjects, Transform[] destinations, float timeToWait)
        {
            yield return new WaitForSecondsRealtime(timeToWait);
            foreach (GameObject lerpObj in lerpObjects)
            {
                lerpObj.SetActive(false);
            }
            foreach (Transform destObj in destinations)
            {
                destObj.gameObject.SetActive(false);
            }
            controlObj.SetActive(false);
        }


    }
}

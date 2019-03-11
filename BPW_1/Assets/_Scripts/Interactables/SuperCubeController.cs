using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCubeController : MonoBehaviour
{
    public bool IsOnHand = true;

    private Vector3 currentPosition;
    private Vector3 target;
    private float speed;

    public void SetDestination(Vector3 _target, float _speed)
    {
        currentPosition = transform.position;
        target = _target;
        speed = _speed;
        StartCoroutine(MoveCubeToTarget());
    }

    public IEnumerator MoveCubeToTarget()
    {
        var waitTime = 0.04f;
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //use WaitForSecondsRealtime if you want it to be unaffected by timescale
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(currentPosition, target) < 0.1f ) //add a check here or in the "while" to break out of the loop!
            {
                break;
            }
        }
    }
}
